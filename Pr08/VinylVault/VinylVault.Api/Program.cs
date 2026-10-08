using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VinylVault.Api.Data;
using VinylVault.Api.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<VinylVaultContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<VinylVaultContext>()
    .AddApiEndpoints();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("SecurePolicy", policy =>
    {
        policy.WithOrigins(
            "https://localhost:7280"
            )
        .AllowCredentials()
        .WithMethods("GET", "POST", "PUT", "DELETE")
        .WithHeaders("Content-Type", "Authorization");
    });
});

builder.Services.AddScoped<IRecordsRepository, RecordsRepository>();

var app = builder.Build();

app.UseCors("SecurePolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapIdentityApi<IdentityUser>();
app.MapControllers();

app.Run();

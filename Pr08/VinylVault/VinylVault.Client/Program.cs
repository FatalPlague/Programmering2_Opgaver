using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VinylVault.Client;
using VinylVault.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<AuthState>();

builder.Services.AddScoped(sp => new HttpClient(new AuthHeaderHandler(sp.GetRequiredService<AuthState>()) { InnerHandler = new HttpClientHandler() })
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

await builder.Build().RunAsync();

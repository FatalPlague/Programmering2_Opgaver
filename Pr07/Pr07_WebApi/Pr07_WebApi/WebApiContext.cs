using Microsoft.EntityFrameworkCore;
using Pr07_WebApi.Models;

namespace Pr07_WebApi
{
    public class WebApiContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        
        public WebApiContext(DbContextOptions dbContextOptions) :
            base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable(nameof(Books));


            base.OnModelCreating(modelBuilder);
        }
    }
}

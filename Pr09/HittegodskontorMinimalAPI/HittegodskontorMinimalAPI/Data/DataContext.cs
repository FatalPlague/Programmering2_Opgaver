using HittegodskontorMinimalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HittegodskontorMinimalAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Item>().ToTable("Items");


            base.OnModelCreating(modelBuilder);
        }
    }

    
}

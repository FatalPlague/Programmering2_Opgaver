using FishyRecipeManager.Model;
using Microsoft.EntityFrameworkCore;

namespace FishyRecipeManager.Data
{
    public class Context : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }

        public Context(DbContextOptions options) :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .HasOne<Category>(recipe => recipe.Category)
                .WithMany(category => category.Recipes)
                .HasForeignKey(recipe => recipe.CategoryId);
        }
    }
}

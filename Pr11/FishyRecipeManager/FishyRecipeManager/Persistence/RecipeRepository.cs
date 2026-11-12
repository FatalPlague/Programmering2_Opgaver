using FishyRecipeManager.Data;
using FishyRecipeManager.Model;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FishyRecipeManager.Persistence
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly Context _context;

        public RecipeRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateAsync(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Recipe? recipeToDelete = await GetByIdAsync(id);
            if (recipeToDelete == null) return;

            _context.Recipes.Remove(recipeToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Recipe>> GetAllAsync()
        {
            return await _context.Recipes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Recipe>> GetByCategoryId(int id)
        {
            return await _context.Recipes
                .AsNoTracking()
                .Where(x => x.CategoryId == id)
                .ToListAsync();
        }

        public async Task<Recipe> GetByIdAsync(int id)
        {
            return await _context.Recipes
                .FindAsync(id);
        }

        public async Task UpdateAsync(Recipe recipe)
        {
            Recipe? recipeToUpdate = await GetByIdAsync(recipe.Id);

            recipeToUpdate.Name = recipe.Name;
            recipeToUpdate.PrepTime = recipe.PrepTime;
            recipeToUpdate.Servings = recipe.Servings;
            recipeToUpdate.Image = recipe.Image;
            recipeToUpdate.CategoryId = recipe.CategoryId;
            recipeToUpdate.Description = recipe.Description;
            recipeToUpdate.Ingredients = recipe.Ingredients;
            recipeToUpdate.Instructions = recipe.Instructions;

            await _context.SaveChangesAsync();
        }
    }
}

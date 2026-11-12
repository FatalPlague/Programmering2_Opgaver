using FishyRecipeManager.Model;

namespace FishyRecipeManager.Persistence
{
    public interface IRecipeRepository
    {
        Task CreateAsync(Recipe recipe);
        Task DeleteAsync(int id);
        Task UpdateAsync(Recipe recipe);
        Task<List<Recipe>> GetAllAsync();
        Task<List<Recipe>> GetByCategoryId(int categoryId);
        Task<Recipe> GetByIdAsync(int id);
    }
}

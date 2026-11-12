using FishyRecipeManager.Model;

namespace FishyRecipeManager.Persistence
{
    public interface ICategoryRepository
    {
        Task CreateAsync(Category category);
        Task DeleteAsync(int id);
        Task UpdateAsync (Category category);
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
    }
}

using FishyRecipeManager.Data;
using FishyRecipeManager.Model;
using Microsoft.EntityFrameworkCore;

namespace FishyRecipeManager.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Category? categoryToDelete = await GetByIdAsync(id);
            if (categoryToDelete == null) return;

            _context.Categories.Remove(categoryToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories
                .FindAsync(id);
        }

        public async Task UpdateAsync(Category category)
        {
            Category? categoryToUpdate = await GetByIdAsync(category.Id);

            categoryToUpdate.Name = category.Name;

            await _context.SaveChangesAsync();
        }
    }
}

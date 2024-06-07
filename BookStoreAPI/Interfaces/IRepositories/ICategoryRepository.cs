using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces.IRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> AddCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(int id, Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }

}

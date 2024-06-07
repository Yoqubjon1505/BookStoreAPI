using BookStoreAPI.Interfaces.IRepositories;
using BookStoreAPI.Models;

namespace BookStoreAPI.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepository.GetCategoriesAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task<Category> AddCategory(Category category)
        {
            return await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task<bool> UpdateCategory(int id, Category category)
        {
            return await _categoryRepository.UpdateCategoryAsync(id, category);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            return await _categoryRepository.DeleteCategoryAsync(id);
        }
    }
}


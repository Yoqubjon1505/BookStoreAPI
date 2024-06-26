using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces.IRepositories
{
    public interface IUserRepository <T> where T : User
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T intity);
        Task<bool> UpdateAsync(Guid id, T intity);
        Task<bool> DeleteAsync(Guid id);
    }
}

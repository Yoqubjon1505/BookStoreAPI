using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces.IRepositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> AddAuthorAsync(Author author);
        Task<bool> UpdateAuthorAsync(int id, Author author);
        Task<bool> DeleteAuthorAsync(int id);
    }
}

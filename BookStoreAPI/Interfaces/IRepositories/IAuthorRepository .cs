using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces.IRepositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(Guid id);
        Task<Author> AddAuthorAsync(Author author);
        Task<bool> UpdateAuthorAsync(Guid id, Author author);
        Task<bool> DeleteAuthorAsync(Guid id);
    }
}

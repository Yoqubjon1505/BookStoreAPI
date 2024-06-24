using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces.IRepositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(Guid id);
        Task<Book> AddBookAsync(Book book);
        Task<bool> UpdateBookAsync(Guid id, Book book);
        Task<bool> DeleteBookAsync(Guid id);
    }
}

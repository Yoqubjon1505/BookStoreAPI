using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces.IRepositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<bool> UpdateBookAsync(int id, Book book);
        Task<bool> DeleteBookAsync(int id);
    }
}

using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces.IRepositories
{
    public interface IBookAuthorRepository
    {
        Task<IEnumerable<BookAuthor>> GetBookAuthorsAsync();
        Task<BookAuthor> GetBookAuthorByIdAsync(int bookId, int authorId);
        Task<BookAuthor> AddBookAuthorAsync(BookAuthor bookAuthor);
        Task<bool> UpdateBookAuthorAsync(int bookId, int authorId, BookAuthor bookAuthor);
        Task<bool> DeleteBookAuthorAsync(int bookId, int authorId);
    }

}

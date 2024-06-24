using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces.IRepositories
{
    public interface IBookAuthorRepository
    {
        Task<IEnumerable<BookAuthor>> GetBookAuthorsAsync();
        Task<BookAuthor> GetBookAuthorByIdAsync(Guid bookId, Guid authorId);
        Task<BookAuthor> AddBookAuthorAsync(BookAuthor bookAuthor);
        Task<bool> UpdateBookAuthorAsync(Guid bookId, Guid authorId, BookAuthor bookAuthor);
        Task<bool> DeleteBookAuthorAsync(Guid bookId, Guid authorId);
    }

}

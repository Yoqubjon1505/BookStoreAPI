using BookStoreAPI.Interfaces.IRepositories;
using BookStoreAPI.Models;

namespace BookStoreAPI.Services
{
    public class BookAuthorService
    {
        private readonly IBookAuthorRepository _bookAuthorRepository;

        public BookAuthorService(IBookAuthorRepository bookAuthorRepository)
        {
            _bookAuthorRepository = bookAuthorRepository;
        }

        public async Task<IEnumerable<BookAuthor>> GetBookAuthors()
        {
            return await _bookAuthorRepository.GetBookAuthorsAsync();
        }

        public async Task<BookAuthor> GetBookAuthor(Guid bookId, Guid authorId)
        {
            return await _bookAuthorRepository.GetBookAuthorByIdAsync(bookId, authorId);
        }

        public async Task<BookAuthor> AddBookAuthor(BookAuthor bookAuthor)
        {
            return await _bookAuthorRepository.AddBookAuthorAsync(bookAuthor);
        }

        public async Task<bool> UpdateBookAuthor(Guid bookId, Guid authorId, BookAuthor bookAuthor)
        {
            return await _bookAuthorRepository.UpdateBookAuthorAsync(bookId, authorId, bookAuthor);
        }

        public async Task<bool> DeleteBookAuthor(Guid bookId, Guid authorId)
        {
            return await _bookAuthorRepository.DeleteBookAuthorAsync(bookId, authorId);
        }
    }

}

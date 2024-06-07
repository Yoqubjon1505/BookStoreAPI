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

        public async Task<BookAuthor> GetBookAuthor(int bookId, int authorId)
        {
            return await _bookAuthorRepository.GetBookAuthorByIdAsync(bookId, authorId);
        }

        public async Task<BookAuthor> AddBookAuthor(BookAuthor bookAuthor)
        {
            return await _bookAuthorRepository.AddBookAuthorAsync(bookAuthor);
        }

        public async Task<bool> UpdateBookAuthor(int bookId, int authorId, BookAuthor bookAuthor)
        {
            return await _bookAuthorRepository.UpdateBookAuthorAsync(bookId, authorId, bookAuthor);
        }

        public async Task<bool> DeleteBookAuthor(int bookId, int authorId)
        {
            return await _bookAuthorRepository.DeleteBookAuthorAsync(bookId, authorId);
        }
    }

}

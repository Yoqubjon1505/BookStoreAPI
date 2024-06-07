using BookStoreAPI.Infrastructure;
using BookStoreAPI.Interfaces.IRepositories;
using BookStoreAPI.Interfaces;
using BookStoreAPI.Models;
using System.Net.Http.Headers;

namespace BookStoreAPI.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.GetBooksAsync();
        }

        public async Task<Book> GetBook(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        public async Task<Book> AddBook(Book book)
        {
            return await _bookRepository.AddBookAsync(book);
        }

        public async Task<bool> UpdateBook(int id, Book book)
        {
            return await _bookRepository.UpdateBookAsync(id, book);
        }

        public async Task<bool> DeleteBook(int id)
        {
            return await _bookRepository.DeleteBookAsync(id);
        }
    }





}
using BookStoreAPI.Interfaces.IRepositories;
using BookStoreAPI.Models;

namespace BookStoreAPI.Services
{
    public class AuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _authorRepository.GetAuthorsAsync();
        }

        public async Task<Author> GetAuthor(int id)
        {
            return await _authorRepository.GetAuthorByIdAsync(id);
        }

        public async Task<Author> AddAuthor(Author author)
        {
            return await _authorRepository.AddAuthorAsync(author);
        }

        public async Task<bool> UpdateAuthor(int id, Author author)
        {
            return await _authorRepository.UpdateAuthorAsync(id, author);
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            return await _authorRepository.DeleteAuthorAsync(id);
        }
    }

}

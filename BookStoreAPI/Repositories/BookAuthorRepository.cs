using BookStoreAPI.Infrastructure;
using BookStoreAPI.Interfaces.IRepositories;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        private readonly BookStoreContext _context;

        public BookAuthorRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookAuthor>> GetBookAuthorsAsync()
        {
            return await _context.BookAuthors.Include(ba => ba.Book).Include(ba => ba.Author).ToListAsync();
        }

        public async Task<BookAuthor> GetBookAuthorByIdAsync(Guid bookId, Guid authorId)
        {
            return await _context.BookAuthors.Include(ba => ba.Book).Include(ba => ba.Author)
                                             .FirstOrDefaultAsync(ba => ba.BookId == bookId && ba.AuthorId == authorId);
        }

        public async Task<BookAuthor> AddBookAuthorAsync(BookAuthor bookAuthor)
        {
            _context.BookAuthors.Add(bookAuthor);
            await _context.SaveChangesAsync();
            return bookAuthor;
        }

        public async Task<bool> UpdateBookAuthorAsync(Guid bookId, Guid authorId, BookAuthor bookAuthor)
        {
            if (bookId != bookAuthor.BookId || authorId != bookAuthor.AuthorId)
            {
                return false;
            }

            _context.Entry(bookAuthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookAuthorExists(bookId, authorId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> DeleteBookAuthorAsync(Guid bookId, Guid authorId)
        {
            var bookAuthor = await _context.BookAuthors.FindAsync(bookId, authorId);
            if (bookAuthor == null)
            {
                return false;
            }

            _context.BookAuthors.Remove(bookAuthor);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool BookAuthorExists(Guid bookId, Guid authorId)
        {
            return _context.BookAuthors.Any(ba => ba.BookId == bookId && ba.AuthorId == authorId);
        }
    }

}

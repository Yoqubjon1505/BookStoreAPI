
using BookStoreAPI.Infrastructure;
using BookStoreAPI.Interfaces.IRepositories;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.Include(b => b.Category)
                .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author).ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.Include(b => b.Category)
                .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> UpdateBookAsync(int id, Book book)
        {
            if (id != book.Id)
            {
                return false;
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}

using BookStoreAPI.Infrastructure;
using BookStoreAPI.Interfaces.IRepositories;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories
{
    public class ReaderRepository : IUserRepository<Reader>
    {
        private readonly BookStoreContext _context;

        public ReaderRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<Reader> AddAsync(Reader entity)
        {
            _context.Readers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var reader = await _context.Readers.FindAsync(id);
            if (reader == null)
            {
                return false;
            }

            _context.Readers.Remove(reader);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Reader>> GetAsync()
        {
            return await _context.Readers.ToListAsync();
        }

        public async Task<Reader> GetByIdAsync(Guid id)
        {
            return await _context.Readers.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Guid id, Reader entity)
        {
            var reader = await _context.Readers.FindAsync(id);
            if (reader == null)
            {
                return false;
            }

            _context.Entry(reader).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}

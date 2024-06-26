using BookStoreAPI.Infrastructure;
using BookStoreAPI.Interfaces.IRepositories;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories
{
    public class AdminRepository : IUserRepository<Admin>
    {
        BookStoreContext _storeContext;
        public AdminRepository(BookStoreContext storeContext)
        {
                _storeContext = storeContext;
        }

        async Task<Admin> IUserRepository<Admin>.AddAsync(Admin entity)
        {
           _storeContext.Admins.Add(entity);
            await _storeContext.SaveChangesAsync();
            return entity;
        }

         async Task<bool> IUserRepository<Admin>.DeleteAsync(Guid id)
        {
            var admin = await _storeContext.Admins.FindAsync(id);
            if (admin == null)
            {
                return false;
            }

            _storeContext.Admins.Remove(admin);
          
            await _storeContext.SaveChangesAsync();
            return true;
        }

        async  Task<IEnumerable<Admin>> IUserRepository<Admin>.GetAsync()
        {
            return await _storeContext.Admins.ToListAsync();
        }

        async  Task<Admin> IUserRepository<Admin>.GetByIdAsync(Guid id)
        {
           return await _storeContext.Admins.FindAsync(id);
        }

         async  Task<bool> IUserRepository<Admin>.UpdateAsync(Guid id, Admin intity)
        {
            var admin = await _storeContext.Admins.FindAsync(id);
            if (admin == null)
            {
                return false;
            }

            _storeContext.Entry(admin).CurrentValues.SetValues(intity);
            await _storeContext.SaveChangesAsync();
            return true;
        }
    }
}

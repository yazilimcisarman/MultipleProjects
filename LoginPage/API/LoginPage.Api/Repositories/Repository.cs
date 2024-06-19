

using LoginPage.Api.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LoginPage.Api.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UserDbContext _context;

        public Repository(UserDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
           _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByUserIdAsync(string userId)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(u => EF.Property<string>(u, "UserId") == userId);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

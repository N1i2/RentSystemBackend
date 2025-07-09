using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RoomRentalSystem.Domain.Entities;
using RoomRentalSystem.Domain.IRepositories;
using RoomRentalSystem.Persistence.DependencyInjection;
using RoomRentalSystem.Persistence.Exceptions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RoomRentalSystem.Persistence.Repositories
{
    public class BaseRepository<T>(InfrastructureServiceRegistration context) : IRepository<T> where T: BaseEntity
    {
        public readonly InfrastructureServiceRegistration _context = context;
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate != null)
            {
                IQueryable<T> query = _dbSet;

                query = query.Where(predicate);

                return await query.ToListAsync();
            }

            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
    }
}

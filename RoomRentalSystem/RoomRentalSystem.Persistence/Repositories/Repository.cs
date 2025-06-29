using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RoomRentalSystem.Domain.Entities;
using RoomRentalSystem.Domain.IRepositories;
using RoomRentalSystem.Persistence.Data;
using RoomRentalSystem.Persistence.Exceptions;

namespace RoomRentalSystem.Persistence.Repositories
{
    public class Repository<T>(AppDbContext appDbContext) : IRepository<T> where T: BaseEntity
    {
        public readonly AppDbContext _appDbContext = appDbContext;
        private readonly DbSet<T> _dbSet = appDbContext.Set<T>();

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id)
                ?? throw new PersistenceException($"{typeof(T).Name} with id = \'{id}\' not found");
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
    }
}

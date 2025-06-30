using Microsoft.EntityFrameworkCore;
using RoomRentalSystem.Domain.Entities;
using RoomRentalSystem.Persistence.Exceptions;

namespace RoomRentalSystem.Persistence.Repositories
{
    public class UserRepository(ConfigureDependencyInjection context) : Repository<User>(context), IUserRepository
    {
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Set<User>()
                       .Include(u => u.Roles) 
                       .FirstOrDefaultAsync(u => u.Email == email)
                   ?? throw new PersistenceException($"User with email '{email}' not found");
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Set<User>()
                .AnyAsync(u => u.Email == email);
        }
    }
}
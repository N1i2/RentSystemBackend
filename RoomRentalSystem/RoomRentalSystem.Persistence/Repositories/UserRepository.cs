using Microsoft.EntityFrameworkCore;
using RoomRentalSystem.Domain.Entities;
using RoomRentalSystem.Persistence.Data;
using RoomRentalSystem.Persistence.Exceptions;

namespace RoomRentalSystem.Persistence.Repositories
{
    public class UserRepository(AppDbContext context) : Repository<User>(context), IUserRepository
    {
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _appDbContext.Set<User>()
                       .Include(u => u.UserRoles)
                       .ThenInclude(ur => ur.Role)
                       .FirstOrDefaultAsync(u => u.Email == email)
                   ?? throw new PersistenceException($"User with email '{email}' not found");
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _appDbContext.Set<User>()
                .AnyAsync(u => u.Email == email);
        }
    }
}

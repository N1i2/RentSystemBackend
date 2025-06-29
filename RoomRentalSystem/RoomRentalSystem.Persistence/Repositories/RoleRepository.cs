using Microsoft.EntityFrameworkCore;
using RoomRentalSystem.Domain.Entities;
using RoomRentalSystem.Persistence.Data;
using RoomRentalSystem.Persistence.Exceptions;

namespace RoomRentalSystem.Persistence.Repositories
{
    public class RoleRepository(AppDbContext context) : Repository<Role>(context), IRoleRepository
    {
        public async Task<Role> GetByNameAsync(string name)
        {
            return await _appDbContext.Set<Role>()
                       .FirstOrDefaultAsync(r => r.Name == name)
                   ?? throw new PersistenceException($"Role '{name}' not found");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RoomRentalSystem.Domain.Entities;
using RoomRentalSystem.Persistence.DependencyInjection;
using RoomRentalSystem.Persistence.Exceptions;

namespace RoomRentalSystem.Persistence.Repositories
{
    public class RoleRepository(InfrastructureServiceRegistration context) : BaseRepository<Role>(context), IRoleRepository
    {
        public async Task<Role> GetByNameAsync(string name)
        {
            return await _context.Set<Role>()
                       .FirstOrDefaultAsync(r => r.Name == name)
                   ?? throw new PersistenceException($"Role with name '{name}' not found");
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Set<Role>()
                .AnyAsync(r => r.Name == name);
        }
    }
}

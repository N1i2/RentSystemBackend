using RoomRentalSystem.Domain.Entities;
using RoomRentalSystem.Domain.IRepositories;

public interface IRoleRepository : IRepository<Role>
{
    Task<Role> GetByNameAsync(string name);
}
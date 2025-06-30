using RoomRentalSystem.Domain.Entities;
using RoomRentalSystem.Domain.IRepositories;

public interface IRoleRepository : IRepository<Role>
{
    public Task<Role> GetByNameAsync(string name);
    public Task<bool> ExistsByNameAsync(string name);
}
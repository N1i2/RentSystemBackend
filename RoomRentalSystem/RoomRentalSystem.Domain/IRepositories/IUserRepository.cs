using RoomRentalSystem.Domain.Entities;
using RoomRentalSystem.Domain.IRepositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email);
    Task<bool> ExistsByEmailAsync(string email);
}
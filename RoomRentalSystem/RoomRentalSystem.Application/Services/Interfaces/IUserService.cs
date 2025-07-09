using RoomRentalSystem.Application.DTOs;

namespace RoomRentalSystem.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> CreateUserAsync(CreateUserDto userDto);
        Task<UserDto> UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(Guid id);
    }
}

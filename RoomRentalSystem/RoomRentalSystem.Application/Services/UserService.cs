using RoomRentalSystem.Application.DTOs;
using RoomRentalSystem.Application.Interfaces;
using RoomRentalSystem.Domain.Entities;
using ApplicationException = RoomRentalSystem.Application.Exceptions.ApplicationException;

namespace RoomRentalSystem.Application.Services
{
    public class UserService(IUserRepository userRepository, IRoleRepository roleRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IRoleRepository _roleRepository = roleRepository;

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new ApplicationException("User not found");
            }

            return MapToDto(user);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(MapToDto).ToList();
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto userDto)
        {
            if (await _userRepository.ExistsByEmailAsync(userDto.Email))
            {
                throw new ApplicationException("User with this email already exists");
            }

            var user = User.Create(
                userDto.PhoneNumber,
                userDto.Email,
                HashPassword(userDto.Password)
            );

            foreach (var roleName in userDto.Roles)
            {
                var role = await _roleRepository.GetByNameAsync(roleName);
                if (role == null)
                {
                    throw new ApplicationException($"Role '{roleName}' not found");
                }

                user.AddRole(role);
            }

            await _userRepository.AddAsync(user);

            return MapToDto(user);
        }

        public Task<UserDto> UpdateUserAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        private static UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Roles = user.UserRoles.Select(ur => ur.Role.Name).ToList()
            };
        }

        private static string HashPassword(string password)
            => BCrypt.Net.BCrypt.HashPassword(password);
    }
}
using Mapster;
using RoomRentalSystem.Application.DTOs;
using RoomRentalSystem.Application.Services.Interfaces;
using RoomRentalSystem.Domain.Constants;
using RoomRentalSystem.Domain.Entities;
using RoomRentalSystem.Domain.IRepositories;
using ApplicationException = RoomRentalSystem.Application.Exceptions.ApplicationException;

namespace RoomRentalSystem.Application.Services
{
    public class UserService(
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IPasswordHasher passwordHasher) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user.Adapt<UserDto>();
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Adapt<List<UserDto>>();
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto userDto)
        {
            if (await _userRepository.ExistsByEmailAsync(userDto.Email))
            {
                throw new ApplicationException("User with this email already exists");
            }

            var roles = new List<Role>();
            foreach (var roleId in userDto.RoleIds)
            {
                var role = await _roleRepository.GetByIdAsync(roleId);
                if (role == null)
                {
                    throw new ApplicationException($"Role with ID '{roleId}' not found");
                }
                roles.Add(role);
            }

            var user = User.Create(
                userDto.PhoneNumber,
                userDto.Email,
                _passwordHasher.HashPassword(userDto.Password),
                roles);

            await _userRepository.AddAsync(user);
            return user.Adapt<UserDto>();
        }

        public Task<UserDto> UpdateUserAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
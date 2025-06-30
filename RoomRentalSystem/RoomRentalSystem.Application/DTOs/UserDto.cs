using RoomRentalSystem.Domain.Entities;

namespace RoomRentalSystem.Application.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Role> Roles { get; set; } =[];
    }
}

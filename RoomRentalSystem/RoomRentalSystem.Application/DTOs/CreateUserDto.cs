namespace RoomRentalSystem.Application.DTOs
{
    public class CreateUserDto
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }
}

using RoomRentalSystem.Application.Services.Interfaces;

namespace RoomRentalSystem.Application.Services;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password) // TODO: salt
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
    public bool VerifyPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
namespace RoomRentalSystem.Application.DTOs;

public record RefreshTokenDto
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}
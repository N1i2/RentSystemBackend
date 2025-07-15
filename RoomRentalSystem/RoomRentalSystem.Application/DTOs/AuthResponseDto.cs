namespace RoomRentalSystem.Application.DTOs;

public record AuthResponseDto
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}
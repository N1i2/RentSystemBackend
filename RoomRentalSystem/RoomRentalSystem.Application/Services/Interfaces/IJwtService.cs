using System.Security.Claims;

namespace RoomRentalSystem.Application.Services.Interfaces;

public interface IJwtService
{
    public string GenerateToken(IEnumerable<Claim> claims);
    public string GenerateRefreshToken();
    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}
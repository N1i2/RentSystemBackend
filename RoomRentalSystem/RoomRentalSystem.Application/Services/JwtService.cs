using RoomRentalSystem.Application.Services.Interfaces;
using System.Security.Claims;
using System.Text;

namespace RoomRentalSystem.Application.Services;

public class JwtService: IJwtService
{
    private readonly string _key;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly int _expireMinutes;
    private readonly int _refreshTokenExpireDays;

    public string GenerateToken(IEnumerable<Claim> claims)
    {

    }

    public string GenerateRefreshToken() => Guid.NewGuid().ToString();

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {

    }
}
using Microsoft.AspNetCore.Mvc;
using RoomRentalSystem.Application.DTOs;
using RoomRentalSystem.Application.Services.Interfaces;

namespace RoomRentalSystem.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(IUserService userService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserDto dto)
    {
        await userService.CreateUserAsync(dto);

        return Ok();
    }
}
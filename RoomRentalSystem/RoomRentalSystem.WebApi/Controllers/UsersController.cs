using Microsoft.AspNetCore.Mvc;
using RoomRentalSystem.Application.DTOs;
using RoomRentalSystem.Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    /**
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
    {
        var result = await _userService.CreateUserAsync(userDto);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return CreatedAtAction(nameof(GetUserById), new { id = result.Data.Id }, result.Data);
    }
    **/
}
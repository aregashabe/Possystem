using Microsoft.AspNetCore.Mvc;
using POSsystem.DTOs;
using POSsystem.Entities;
using POSsystem.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace POSsystem.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
[Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        var createdUser = await _userService.createUserAsync(user);
        return CreatedAtAction(nameof(CreateUser), new { id = createdUser.Id }, createdUser);
    }
    [HttpPost("login")]
public async Task<IActionResult> Login(LoginDto dto)
{
    var result = await _userService.LoginAsync(
        dto.Email,
        dto.Password);

    if (result == null)
    {
        return Unauthorized(new
        {
            message = "Invalid email or password."
        });
    }

    Response.Cookies.Append(
        "access_token",
        result.Token,
        new CookieOptions
        {
            HttpOnly = true,
            Secure = false,
            SameSite = SameSiteMode.Lax,
            Expires = DateTimeOffset.UtcNow.AddHours(2)
        });

    return Ok(new
    {
        result.UserId,
        result.FirstName,
        result.LastName,
        result.Email,
        result.UserRole
    });
}
[Authorize]
[HttpGet("me")]
public IActionResult Me()
{
    return Ok(new
    {
        FirstName = User.FindFirstValue("FirstName"),
        LastName = User.FindFirstValue("LastName"),
        Email = User.FindFirstValue(ClaimTypes.Email),
        Role = User.FindFirstValue(ClaimTypes.Role)
    });
}
[Authorize(Roles = "Admin")]
[HttpGet]
public async Task<IActionResult> GetAllUsers()
{
    var users = await _userService.GetAllUsersAsync();

    return Ok(users);
}
}
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using POSsystem.Data;
using POSsystem.DTOs;
using POSsystem.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace POSsystem.Services;
public class UserService : IUserService
{
    private readonly POSDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public UserService(POSDbContext dbContext,IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration=configuration;
    }

    public async Task<User> createUserAsync(User user)
    {
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }
    public async Task<LoginResponseDto?> LoginAsync(
        string email,
        string password)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Email == email);

        if (user == null)
            return null;

        bool passwordValid =
            BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

        if (!passwordValid)
            return null;

        var token = GenerateJwtToken(user);

        return new LoginResponseDto
        {
            Token = token,
            UserId = user.Id,
           Firstname = user.Firstname,
           Lastname = user.Lastname,
           Email = user.Email,
           UserRole = user.UserRole
        };
    }

    private string GenerateJwtToken(User user)
{
    var jwtKey = _configuration["Jwt:Key"]
        ?? throw new InvalidOperationException("JWT Key is missing.");

    var issuer = _configuration["Jwt:Issuer"];
    var audience = _configuration["Jwt:Audience"];

    var claims = new List<Claim>
    {
        new Claim(
            JwtRegisteredClaimNames.Sub,
            user.Id.ToString()),

        new Claim(
            ClaimTypes.Email,
            user.Email),

        new Claim(
            "Firstname",
            user.Firstname),

        new Claim(
            "Lastname",
            user.Lastname),

        new Claim(
            ClaimTypes.Role,
            user.UserRole)
    };

    var key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(jwtKey));

    var credentials = new SigningCredentials(
        key,
        SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
        issuer: issuer,
        audience: audience,
        claims: claims,
        expires: DateTime.UtcNow.AddHours(2),
        signingCredentials: credentials);

    return new JwtSecurityTokenHandler()
        .WriteToken(token);
}
    public async Task<List<User>> GetAllUsersAsync()
{
    return await _dbContext.Users
        .ToListAsync();
}
}
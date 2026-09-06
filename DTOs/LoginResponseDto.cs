namespace POSsystem.DTOs;

public class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;
    public int UserId { get; set; }
    public string Firstname { get; set; } = string.Empty;
    public string Lastname {get;set;}=string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserRole { get; set; } = string.Empty;
}
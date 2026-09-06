namespace POSsystem.DTOs;

public class CreateUserDto
{
    public string Firstname { get; set; } = "";
    public string Lastname { get; set; } = "";
    public string Email { get; set; } = "";
    public string Mobile { get; set; } = "";
    public string UserRole { get; set; } = "";
    public string Password { get; set; } = "";
}
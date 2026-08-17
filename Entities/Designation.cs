namespace POSsystem.Entities;

public class Designation
{
    public int Id { get; set; }

    public string DesignationName { get; set; } = string.Empty;
    public string data { get; set; } = string.Empty;

    public int UserId { get; set; }

    public User User { get; set; } = null!;
}
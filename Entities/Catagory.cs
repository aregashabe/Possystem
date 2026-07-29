namespace POSsystem.Entities;

public class Category
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
}
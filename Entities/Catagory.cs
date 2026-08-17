namespace POSsystem.Entities;

public class Category
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<Foodmenu> Foodmenus { get; set; } = new List<Foodmenu>(); 
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
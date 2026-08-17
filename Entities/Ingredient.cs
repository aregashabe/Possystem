namespace POSsystem.Entities;

public class Ingredient
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int CategoryId { get; set; }

    public int IngredientUnitId { get; set; }

    public decimal AlertQuantity { get; set; }

    public string Description { get; set; } = string.Empty;

    // Navigation properties
    public Category Category { get; set; } = null!;

    public IngredientUnit IngredientUnit { get; set; } = null!;

    // One Ingredient → Many PurchaseItems
    public ICollection<PurchaseItem> Items { get; set; }
        = new List<PurchaseItem>();
}
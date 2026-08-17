namespace POSsystem.Entities;
public class PurchaseItem
{
    public int Id { get; set; }

    public int PurchaseId { get; set; }

    public int IngredientId { get; set; }

    public decimal PurchasePrice { get; set; }

    public decimal Quantity { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public decimal Total { get; set; }

    public string Unit { get; set; } = string.Empty;

    public Purchase Purchase { get; set; } = null!;

    public Ingredient Ingredient { get; set; } = null!;
}
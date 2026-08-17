namespace POSsystem.Entities;

public class PosOrderItem
{
    public int Id { get; set; }

    public int PosOrderId { get; set; }

    public int FoodMenuId { get; set; }

    public decimal SalesPrice { get; set; }

    public decimal Quantity { get; set; }

    // Navigation
    public PosOrder PosOrder { get; set; } = null!;

    public Foodmenu Foodmenu { get; set; } = null!;
}
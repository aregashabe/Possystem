namespace POSsystem.DTOs;

public class PosOrderItemDto
{
    public int FoodMenuId { get; set; }

    public decimal SalesPrice { get; set; }

    public decimal Quantity { get; set; }
}
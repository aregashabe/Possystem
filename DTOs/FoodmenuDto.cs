namespace POSsystem.DTOs;

public class FoodmenuDto
{
    public int Id { get; set; }

    public string FoodmenuName { get; set; } = string.Empty;

    public int CatagoryId { get; set; }

    public int FoodingredientId { get; set; }

    public decimal SalesPrice { get; set; }

    public int VatId { get; set; }

    public string? Description { get; set; }

    public bool VegItem { get; set; }

    public bool Beverage { get; set; }

    public bool Bar { get; set; }

    public string? Photo { get; set; }
}
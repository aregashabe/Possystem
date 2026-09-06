namespace POSsystem.DTOs;

public class IngredientDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int CategoryId { get; set; }

    public int IngredientUnitId { get; set; }

    public decimal AlertQuantity { get; set; }

    public string Description { get; set; } = string.Empty;
}
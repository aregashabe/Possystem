namespace POSsystem.Entities;

public class PosOrder
{
    public int Id { get; set; }

    public required string OrderNumber { get; set; }

    public int CustomerId { get; set; }

    public Customer Customer { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }
}
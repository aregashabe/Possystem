namespace POSsystem.Entities;

public class OrderTable
{
    public int Id { get; set; }

    // Table relationship
    public int TableId { get; set; }

    public Table Table { get; set; } = null!;

    public string OrderNumber { get; set; } = string.Empty;

    public int NumberOfPerson { get; set; }

    // Order relationship
    public int OrderId { get; set; }

    public PosOrder Order { get; set; } = null!;

    public string OrderStatus { get; set; } = string.Empty;

    public DateTime Date { get; set; } = DateTime.Now;
}
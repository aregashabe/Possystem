namespace POSsystem.Entities;

public class PosOrder
{
    public int Id { get; set; }
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }
        // Order information
    public string Options { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public decimal GrandTotal { get; set; }
    public decimal VatAmount { get; set; }
        public int? TableId { get; set; }

    public Table? Table { get; set; }

    // Waiter relationship
    public int? WaiterId { get; set; }

    public Waiter? Waiter { get; set; }

    // Delivery relationship
    public int? DeliveryId { get; set; }

    public Delivery? Delivery { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;
    public string? PaymentStatus { get; set; }

    public string? Hold { get; set; }

    public string? PaymentType { get; set; }
    // User who added the order
    public int? AddedById { get; set; }

    public User? AddedBy { get; set; }

    public string OpenToken { get; set; } = string.Empty;

    public string? BillNumber { get; set; }

    // User who cancelled the order
    public int? CancelById { get; set; }

    public User? CancelBy { get; set; }
     public ICollection<PosOrderItem> Items { get; set; }
        = new List<PosOrderItem>();

}
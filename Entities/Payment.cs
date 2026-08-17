namespace POSsystem.Entities;

public class Payment
{
    public int Id { get; set; }

    public string BillNumber { get; set; } = string.Empty;

    // Order relationship
    public int OrderId { get; set; }

    public PosOrder Order { get; set; } = null!;

    public decimal Total { get; set; }

    public decimal GrandTotal { get; set; }

    public decimal VatAmount { get; set; }

    public string? PaymentType { get; set; }

    // User who added the payment
    public int AddedById { get; set; }

    public User AddedBy { get; set; } = null!;

    public string ShiftToken { get; set; } = string.Empty;

    public string OpenToken { get; set; } = string.Empty;

    public DateTime Date { get; set; } = DateTime.Now;

    public string? Status { get; set; }
}
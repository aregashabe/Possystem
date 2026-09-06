namespace POSsystem.DTOs;

public class PaymentDto
{
    public int Id { get; set; }

    public string BillNumber { get; set; } = string.Empty;

    public int OrderId { get; set; }

    public decimal Total { get; set; }

    public decimal GrandTotal { get; set; }

    public decimal VatAmount { get; set; }

    public string? PaymentType { get; set; }

    public int AddedById { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    public string? Status { get; set; }
}
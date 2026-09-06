namespace POSsystem.DTOs;

public class PosOrderDto
{
    public int? CustomerId { get; set; }

    public int? TableId { get; set; }

    public int? WaiterId { get; set; }

    public int? DeliveryId { get; set; }

    public string Options { get; set; } = string.Empty;

    public decimal Total { get; set; }

    public decimal VatAmount { get; set; }

    public decimal GrandTotal { get; set; }

    public string? PaymentStatus { get; set; }

    public string? PaymentType { get; set; }

    public string? Hold { get; set; }

    public List<PosOrderItemDto> Items { get; set; }
        = new List<PosOrderItemDto>();
}
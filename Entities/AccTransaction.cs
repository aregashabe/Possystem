namespace POSsystem.Entities;

public class AccTransaction
{
    public int Id { get; set; }

    public string AccCode { get; set; } = string.Empty;

    public string AccountsId { get; set; } = string.Empty;

    public string TransNumber { get; set; } = string.Empty;

    public string TransMode { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public string TransType { get; set; } = string.Empty;

    // public string ShiftsToken { get; set; } = string.Empty;

    public string? TranStatus { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;
}
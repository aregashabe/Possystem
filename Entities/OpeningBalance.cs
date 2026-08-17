namespace POSsystem.Entities;

public class OpeningBalance
{
    public int Id { get; set; }

    public string OpeningBalanceNumber { get; set; } = string.Empty;

    // User who added the opening balance
    public int AddedById { get; set; }

    public User AddedBy { get; set; } = null!;

    public decimal Amount { get; set; }

    public string Status { get; set; } = "Active";

    public DateTime Date { get; set; } = DateTime.Now;

    public decimal? ClosingAmount { get; set; }
}
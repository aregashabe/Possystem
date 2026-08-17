namespace POSsystem.Entities;

public class CashDrop
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public string DropOut { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;

    // Foreign key
    public int AddedById { get; set; }

    // Navigation property
    public User AddedBy { get; set; } = null!;

    public string ShiftToken { get; set; } = string.Empty;

    public string OpenToken { get; set; } = string.Empty;

    public DateTime Date { get; set; } = DateTime.Now;
}
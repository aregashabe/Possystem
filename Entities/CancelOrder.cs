namespace POSsystem.Entities;

public class CancelOrder
{
    public int Id { get; set; }

    // Order that was cancelled
    public int OrderId { get; set; }

    public PosOrder Order { get; set; } = null!;

    // User who cancelled the order
    public int CancelById { get; set; }

    public User CancelBy { get; set; } = null!;

    public string Notes { get; set; } = string.Empty;

    // User who added/recorded the cancellation
    public int AddedById { get; set; }

    public User AddedBy { get; set; } = null!;

    public DateTime Date { get; set; } = DateTime.Now;
}
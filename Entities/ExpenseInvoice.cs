namespace POSsystem.Entities;

public class ExpenseInvoice
{
    public int Id { get; set; }

    public int ExpenseId { get; set; }

    public decimal Amount { get; set; }

    public int AddedById { get; set; }

    public DateTime Date { get; set; }

    public DateTime CreateDate { get; set; } = DateTime.Now;

    public string Status { get; set; } = "Active";

    // Navigation properties
    public Expense Expense { get; set; } = null!;

    public User AddedBy { get; set; } = null!;
}
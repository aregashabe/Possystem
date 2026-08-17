namespace POSsystem.Entities;

public class Expense
{
    public int Id { get; set; }

    public string ExpenseName { get; set; } = string.Empty;

    public int AddedById { get; set; }

    // Navigation
    public User AddedBy { get; set; } = null!;

    // One Expense → Many ExpenseInvoices
    public ICollection<ExpenseInvoice> ExpenseInvoices { get; set; }
        = new List<ExpenseInvoice>();
}
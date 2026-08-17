namespace POSsystem.Entities;
public class Purchase
{
    public int Id { get; set; }

    public string InvoiceNumber { get; set; } = string.Empty;

    public decimal PaidAmount { get; set; }

    public decimal DueAmount { get; set; }

    public decimal GrandTotal { get; set; }

    public int SupplierId { get; set; }

    public DateTime InvoiceDate { get; set; }

    public Supplier Supplier { get; set; } = null!;

    public ICollection<PurchaseItem> Items { get; set; }
        = new List<PurchaseItem>();
}
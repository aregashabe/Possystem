namespace POSsystem.Entities;
public class Vat{
    public int Id { get; set; }
    public string VatName{get;set;}
    public string Percentage{get;set;}
    public ICollection<Foodmenu> Foodmenus { get; set; } = new List<Foodmenu>();
    
}
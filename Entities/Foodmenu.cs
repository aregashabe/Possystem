namespace POSsystem.Entities;
public class Foodmenu{
   public int Id { get; set; }
   public string FoodmenuName{get;set;}
   public int CatagoryId { get; set; }
   public string FoodingredientId{get;set;}
   public string SalesPrice{get;set;}
   public int VatId { get; set; }
   public string Description{get;set;}
   public string VegItem{get;set;}
   public string Beverage{get;set;}
   public string Bar{get;set;}
   public string Photo{get;set;}
   public Vat Vat { get; set; } = null!;
   public Category Category { get; set; } = null!;
   public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}

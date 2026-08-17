using Microsoft.EntityFrameworkCore;
using POSsystem.Entities;

namespace POSsystem.Data;

public class POSDbContext(DbContextOptions<POSDbContext> options) 
    : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<PosOrder> PosOrders => Set<PosOrder>();
    public DbSet<IngredientUnit> IngredientUnits => Set<IngredientUnit>();
    public DbSet<Waiter> Waiters => Set<Waiter>();
    public DbSet<Vat> Vats => Set<Vat>();
    public DbSet<Table> Tabless => Set<Table>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Foodmenu> Foodmenus => Set<Foodmenu>();
    public DbSet<Delivery> Deliveries => Set<Delivery>();
    public DbSet<Designation> Designations => Set<Designation>();

}
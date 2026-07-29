using Microsoft.EntityFrameworkCore;
using POSsystem.Entities;

namespace POSsystem.Data;

public class POSDbContext(DbContextOptions<POSDbContext> options) 
    : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<PosOrder> PosOrders => Set<PosOrder>();
    public DbSet<IngredientUnit> IngredientUnits => Set<IngredientUnit>();
}
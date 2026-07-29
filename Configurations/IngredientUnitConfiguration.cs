using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POSsystem.Entities;
namespace POSsystem.Configurations;
public class IngredientUnitConfiguration : IEntityTypeConfiguration<IngredientUnit>
{
    public void Configure(EntityTypeBuilder<IngredientUnit> builder)
    {
        builder.ToTable("IngredientUnits");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.UnitName)
            .IsRequired();
        builder.HasIndex(c => c.UnitName).IsUnique();
        builder.Property(c => c.Description)
            .HasMaxLength(500);
    }
}
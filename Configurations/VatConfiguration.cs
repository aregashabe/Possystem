using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POSsystem.Entities;
namespace POSsystem.Configurations;
public class VatConfiguration:IEntityTypeConfiguration<Vat>{
     public void Configure(EntityTypeBuilder<Vat> builder){
        builder.ToTable("Vat");
builder.Property(c=>c.VatName).IsRequired();
builder.Property(c=>c.Percentage).IsRequired();
builder.HasIndex(c => c.Percentage).IsUnique();
     }
}
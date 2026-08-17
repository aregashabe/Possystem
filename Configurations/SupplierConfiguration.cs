using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POSsystem.Entities;
namespace POSsystem.Configurations;
public class SupplierConfiguration:IEntityTypeConfiguration<Supplier>{
    public void Configure(EntityTypeBuilder<Supplier> builder){
        builder.Property(c=>c.SupplierName).IsRequired();
        builder.Property(c=>c.SupplierEmail).IsRequired();
        builder.Property(c=>c.SupplierMobile).IsRequired();
        builder.HasIndex(c => c.SupplierName).IsUnique();
        builder.HasIndex(c => c.SupplierEmail).IsUnique();
        builder.HasIndex(c => c.SupplierMobile).IsUnique();
    }
}
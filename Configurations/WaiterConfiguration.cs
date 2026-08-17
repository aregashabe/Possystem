using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POSsystem.Entities;
namespace POSsystem.Configurations;
public class WaiterConfiguration:IEntityTypeConfiguration<Waiter>{
    public void Configure(EntityTypeBuilder<Waiter> builder){
        builder.Property(c=>c.WaiterName).IsRequired();
        builder.Property(c=>c.Designation).IsRequired();
        builder.Property(c=>c.Mobile).IsRequired();
        builder.HasIndex(c => c.Mobile).IsUnique();
        builder.Property(c=>c.Description).IsRequired();
    }
}
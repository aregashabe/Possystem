using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POSsystem.Entities;
namespace POSsystem.Configurations;
public class TableConfiguration:IEntityTypeConfiguration<Table>{
    public void Configure(EntityTypeBuilder<Table> builder){
         builder.ToTable("Table");
         builder.Property(c => c.TableName)
            .IsRequired();
        builder.HasIndex(c => c.TableName).IsUnique();
         builder.Property(c => c.Position)
            .IsRequired();
            builder.Property(c => c.SeatCapacity)
            .IsRequired();
    }

}

using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    private const string TableName = "Shipments";
    
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder
            .ToTable(TableName)
            .HasKey(shipment => shipment.Id);
        
        builder
            .HasMany(shipment => shipment.Orders)
            .WithOne(order => order.Shipment)
            .HasForeignKey(order => order.ShipmentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .Property(shipment => shipment.Cost)
            .IsRequired();
        
        builder
            .Property(shipment => shipment.Days)
            .IsRequired();

        builder
            .Property(shipment => shipment.ShipmentType)
            .IsRequired();
    }
}
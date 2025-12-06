using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    private const string TableName = "Orders";
    
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .ToTable(TableName)
            .HasKey(order => order.Id);
        
        builder
            .HasOne(order => order.User)
            .WithMany(user => user.Orders)
            .HasForeignKey(order => order.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(order => order.Shipment)
            .WithMany(shipment => shipment.Orders)
            .HasForeignKey(order => order.ShipmentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasMany(order => order.Items)
            .WithOne(item => item.Order)
            .HasForeignKey(item => item.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(order => order.Payment)
            .WithOne(payment => payment.Order)
            .HasForeignKey<Payment>(payment => payment.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
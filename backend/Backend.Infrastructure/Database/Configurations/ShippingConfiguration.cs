using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class ShippingConfiguration : IEntityTypeConfiguration<Shipping>
{
    public void Configure(EntityTypeBuilder<Shipping> builder)
    {
        builder
            .HasKey(shipping => shipping.Id);
        
        builder
            .HasMany(shipping => shipping.Orders)
            .WithOne(order => order.Shipping)
            .HasForeignKey(order => order.ShippingId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .Property(shipping => shipping.Cost)
            .IsRequired();
        
        builder
            .Property(shipping => shipping.Days)
            .IsRequired();

        builder
            .Property(shipping => shipping.ShippingType)
            .IsRequired();
    }
}
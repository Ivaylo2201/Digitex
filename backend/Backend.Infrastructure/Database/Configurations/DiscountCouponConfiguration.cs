using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class DiscountCouponConfiguration : IEntityTypeConfiguration<DiscountCoupon>
{
    private const string TableName = "DiscountCoupons";
    private const int CodeMaxLength = 10;
    
    public void Configure(EntityTypeBuilder<DiscountCoupon> builder)
    {
        builder
            .ToTable(TableName)
            .HasKey(discountCoupon => discountCoupon.Id);
        
        builder
            .HasOne(discountCoupon => discountCoupon.Order)
            .WithOne(order => order.DiscountCoupon)
            .HasForeignKey<DiscountCoupon>(discountCoupon => discountCoupon.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .Property(discountCoupon => discountCoupon.Code)
            .HasMaxLength(CodeMaxLength);
    }
}
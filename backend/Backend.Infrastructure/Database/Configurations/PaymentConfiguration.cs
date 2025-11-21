using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    private const string TableName = "Payments";

    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder
            .ToTable(TableName)
            .HasKey(payment => payment.Id);

        builder
            .HasOne(payment => payment.Order)
            .WithOne(order => order.Payment)
            .HasForeignKey<Payment>(payment => payment.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
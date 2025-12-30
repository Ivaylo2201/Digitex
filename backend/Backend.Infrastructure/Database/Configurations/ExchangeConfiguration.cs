using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class ExchangeConfiguration : IEntityTypeConfiguration<Exchange>
{
    private const string TableName = "Exchanges";
    
    public void Configure(EntityTypeBuilder<Exchange> builder)
    {
        builder
            .ToTable(TableName)
            .HasKey(exchangeRate => new { exchangeRate.FromCurrencyId, exchangeRate.ToCurrencyId });
        
        builder
            .HasOne(exchangeRate => exchangeRate.FromCurrency)
            .WithMany()
            .HasForeignKey(exchangeRate => exchangeRate.FromCurrencyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(exchangeRate => exchangeRate.ToCurrency)
            .WithMany()
            .HasForeignKey(exchangeRate => exchangeRate.ToCurrencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
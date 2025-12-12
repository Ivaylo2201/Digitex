using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRate>
{
    private const string TableName = "ExchangeRates";
    
    public void Configure(EntityTypeBuilder<ExchangeRate> builder)
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
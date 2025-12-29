using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    private const string TableName = "Currencies";
    private const int IsoCodeMaxLength = 3;
    private const int SignMaxLength = 1;
    
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder
            .ToTable(TableName)
            .HasKey(currency => currency.Id);
        
        builder
            .Property(currency => currency.CurrencyIsoCode)
            .HasMaxLength(IsoCodeMaxLength);
        
        builder
            .Property(currency => currency.Sign)
            .HasMaxLength(SignMaxLength);
    }
}
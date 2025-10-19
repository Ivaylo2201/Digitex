using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    private const string TableName = "Countries";
    private const int CountryNameMaxLength = 25;
    
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder
            .ToTable(TableName)
            .HasKey(country => country.Id);

        builder
            .Property(country => country.CountryName)
            .HasMaxLength(CountryNameMaxLength);
    }
}
using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    private const int NameMaxLength = 20;
    
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(city => city.Id);

        builder
            .Property(city => city.CityName)
            .IsRequired()
            .HasMaxLength(NameMaxLength);
        
        builder
            .HasMany(city => city.Addresses)
            .WithOne(address => address.City)
            .HasForeignKey(address => address.CityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    private const string TableName = "Addresses";
    private const int StreetNameMaxLength = 50;
    
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder
            .ToTable(TableName)
            .HasKey(address => address.Id);
        
        builder
            .HasOne(address => address.City)
            .WithMany(city => city.Addresses)
            .HasForeignKey(address => address.CityId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasMany(address => address.Orders)
            .WithOne(order => order.Address)
            .HasForeignKey(order => order.AddressId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .Property(s => s.StreetName)
            .HasMaxLength(StreetNameMaxLength);
    }
}
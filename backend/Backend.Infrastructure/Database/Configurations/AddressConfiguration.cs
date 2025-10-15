using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder
            .HasKey(address => address.Id);
        
        builder
            .HasOne(address => address.City)
            .WithMany(city => city.Addresses)
            .HasForeignKey(address => address.CityId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(address => address.User)
            .WithMany(user => user.Addresses)
            .HasForeignKey(address => address.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ComplexProperty(address => address.Street, street =>
        {
            street.Property(s => s.StreetName).HasColumnName("StreetName");
            street.Property(s => s.Number).HasColumnName("StreetNumber");
        });
    }
}
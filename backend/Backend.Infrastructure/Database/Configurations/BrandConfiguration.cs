using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    private const string TableName = "Brands";
    private const int BrandNameMaxLength = 25;
    
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder
            .ToTable(TableName)
            .HasKey(brand => brand.Id);
        
        builder
            .Property(brand => brand.BrandName)
            .HasMaxLength(BrandNameMaxLength)
            .IsRequired();
        
        builder
            .HasMany(brand => brand.Products)
            .WithOne(product => product.Brand)
            .HasForeignKey(product => product.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
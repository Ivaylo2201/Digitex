using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class ProductBaseConfiguration : IEntityTypeConfiguration<ProductBase>
{
    private const string TableName = "Products";
    private const int ModelMaxLength = 100;
    private const int ImagePathMaxLength = 50;
    
    public void Configure(EntityTypeBuilder<ProductBase> builder)
    {
        builder
            .ToTable(TableName)
            .UseTptMappingStrategy()
            .HasKey(productBase => productBase.Id);
        
        builder
            .HasOne(productBase => productBase.Brand)
            .WithMany(brand => brand.Products)
            .HasForeignKey(productBase => productBase.BrandId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(productBase => productBase.Model)
            .HasMaxLength(ModelMaxLength)
            .IsRequired();
        
        builder
            .HasIndex(productBase => productBase.Model)
            .IsUnique();
        
        builder
            .Property(productBase => productBase.ImagePath)
            .HasMaxLength(ImagePathMaxLength)
            .IsRequired();
        
        builder
            .Property(productBase => productBase.InitialPrice)
            .IsRequired();
    }
}
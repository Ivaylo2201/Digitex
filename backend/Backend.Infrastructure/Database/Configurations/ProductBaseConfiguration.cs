using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class ProductBaseConfiguration : IEntityTypeConfiguration<ProductBase>
{
    private const string TableName = "Products";
    private const int ModelNameMaxLength = 150;
    private const int RatingDefaultValue = 0;
    
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
            .Property(productBase => productBase.ModelName)
            .HasMaxLength(ModelNameMaxLength)
            .IsRequired();
        
        builder
            .HasIndex(productBase => productBase.ModelName)
            .IsUnique();
        
        builder
            .Property(productBase => productBase.ImagePath)
            .HasColumnType("TEXT")
            .IsRequired();
        
        builder
            .Property(productBase => productBase.InitialPrice)
            .IsRequired();

        builder
            .Property(productBase => productBase.Rating)
            .HasDefaultValue(RatingDefaultValue);
    }
}
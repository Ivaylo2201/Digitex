using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class ProductBaseConfiguration : IEntityTypeConfiguration<ProductBase>
{
    private const string TableName = "Products";
    private const string SuggestionsTableName = "Suggestions";
    private const int ModelNameMaxLength = 150;
    private const int RatingDefaultValue = 0;
    
    public void Configure(EntityTypeBuilder<ProductBase> builder)
    {
        builder
            .ToTable(TableName)
            .UseTptMappingStrategy()
            .HasKey(product => product.Id);
        
        builder
            .HasOne(product => product.Brand)
            .WithMany(brand => brand.Products)
            .HasForeignKey(product => product.BrandId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(product => product.ModelName)
            .HasMaxLength(ModelNameMaxLength)
            .IsRequired();
        
        builder
            .HasIndex(product => product.ModelName)
            .IsUnique();
        
        builder
            .Property(product => product.ImagePath)
            .HasColumnType("TEXT")
            .IsRequired();
        
        builder
            .Property(product => product.InitialPrice)
            .IsRequired();

        builder
            .Property(product => product.Rating)
            .HasDefaultValue(RatingDefaultValue);
        
        builder
            .HasMany(product => product.Sales)
            .WithOne(sale => sale.Product)
            .HasForeignKey(sale => sale.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasMany(product => product.Suggestions)
            .WithMany(product => product.SuggestedBy)
            .UsingEntity(
                SuggestionsTableName,
                product => product
                    .HasOne(typeof(ProductBase))
                    .WithMany()
                    .HasForeignKey("SuggestedProductId")
                    .HasPrincipalKey(nameof(ProductBase.Id)),
                product => product
                    .HasOne(typeof(ProductBase))
                    .WithMany()
                    .HasForeignKey("ProductId")
                    .HasPrincipalKey(nameof(ProductBase.Id)),
                junction => junction
                    .HasKey("ProductId", "SuggestedProductId")
        );
    }
}
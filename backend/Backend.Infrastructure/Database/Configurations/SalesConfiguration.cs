using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class SalesConfiguration : IEntityTypeConfiguration<Sale>
{
    private const string TableName = "Sales";
    
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder
            .ToTable(TableName)
            .HasKey(sale => sale.Id);
        
        builder
            .HasOne(sale => sale.Product)
            .WithMany(product => product.Sales)
            .HasForeignKey(sale => sale.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    private const string TableName = "Carts";
    
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder
            .ToTable(TableName)
            .HasKey(cart => cart.Id);
        
        builder
            .HasOne(cart => cart.User)
            .WithOne(user => user.Cart)
            .HasForeignKey<Cart>(cart => cart.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasMany(cart => cart.Items)
            .WithOne(item => item.Cart)
            .HasForeignKey(item => item.CartId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    private const string TableName = "Users";
    private const string WishlistTableName = "Wishlist";
    private const int UsernameMaxLength = 25;
    private const int EmailMaxLength = 125;
    private const bool IsVerifiedDefaultValue = false;
    
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable(TableName)
            .HasKey(user => user.Id);
        
        builder
            .Property(user => user.Username)
            .HasMaxLength(UsernameMaxLength)
            .IsRequired();
        
        builder
            .Property(user => user.Email)
            .HasMaxLength(EmailMaxLength)
            .IsRequired();

        builder
            .Property(user => user.IsVerified)
            .HasDefaultValue(IsVerifiedDefaultValue);

        builder
            .HasIndex(user => user.Email)
            .IsUnique();
        
        builder
            .HasOne(user => user.Cart)
            .WithOne(cart => cart.User)
            .HasForeignKey<Cart>(cart => cart.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasMany(user => user.Orders)
            .WithOne(order => order.User)
            .HasForeignKey(order => order.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(user => user.Wishlist)
            .WithMany(product => product.LikedBy)
            .UsingEntity(
                WishlistTableName,
                product => product
                    .HasOne(typeof(ProductBase))
                    .WithMany()
                    .HasForeignKey("ProductId")
                    .HasPrincipalKey(nameof(ProductBase.Id)),
                user => user
                    .HasOne(typeof(User))
                    .WithMany()
                    .HasForeignKey("UserId")
                    .HasPrincipalKey(nameof(User.Id)),
                junction => junction
                    .HasKey("UserId", "ProductId"));
        
        builder
            .HasMany(user => user.Addresses)
            .WithOne(address => address.User)
            .HasForeignKey(address => address.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasMany(user => user.Tokens)
            .WithOne(userToken => userToken.User)
            .HasForeignKey(userToken => userToken.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    private const string TableName = "Reviews";
    
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder
            .ToTable(TableName)
            .HasKey(review => review.Id);
        
        builder
            .Property(review => review.Rating)
            .IsRequired();

        builder
            .Property(review => review.Comment)
            .HasColumnType("TEXT");

        builder
        
            .HasOne(review => review.Product)
            .WithMany(product => product.Reviews)
            .HasForeignKey(review => review.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(review => review.User)
            .WithMany(user => user.Reviews)
            .HasForeignKey(review => review.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
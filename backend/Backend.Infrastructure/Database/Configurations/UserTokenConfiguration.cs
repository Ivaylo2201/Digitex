using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
    private const string TableName = "UserTokens";
    
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder
            .ToTable(TableName)
            .HasKey(userToken => userToken.Id);
        
        builder
            .HasOne(userToken => userToken.User)
            .WithMany(userToken => userToken.Tokens)
            .HasForeignKey(userToken => userToken.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasIndex(userToken => userToken.Hash)
            .IsUnique();
    }
}
using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class HddConfiguration : IEntityTypeConfiguration<Hdd>
{
    private const string TableName = "HDDs";
    
    public void Configure(EntityTypeBuilder<Hdd> builder)
    {
        builder
            .ToTable(TableName);
    }
}
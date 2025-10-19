using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class MotherboardConfiguration : IEntityTypeConfiguration<Motherboard>
{
    private const string TableName = "Motherboards";
    
    public void Configure(EntityTypeBuilder<Motherboard> builder)
    {
        builder
            .ToTable(TableName);
    }
}
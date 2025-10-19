using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class MotherboardConfiguration : IEntityTypeConfiguration<Motherboard>
{
    private const string TableName = "Motherboards";
    private const int ChipsetMaxLength = 10;
    
    public void Configure(EntityTypeBuilder<Motherboard> builder)
    {
        builder
            .ToTable(TableName);
        
        builder
            .Property(motherboard => motherboard.Chipset)
            .HasMaxLength(ChipsetMaxLength)
            .IsRequired();
    }
}
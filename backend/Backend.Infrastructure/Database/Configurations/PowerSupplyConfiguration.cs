using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class PowerSupplyConfiguration : IEntityTypeConfiguration<PowerSupply>
{
    private const string TableName = "PowerSupplies";
    
    public void Configure(EntityTypeBuilder<PowerSupply> builder)
    {
        builder
            .ToTable(TableName);
    }
}
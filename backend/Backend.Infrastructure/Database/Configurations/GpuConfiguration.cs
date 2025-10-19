using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class GpuConfiguration : IEntityTypeConfiguration<Gpu>
{
    private const string TableName = "GPUs";
    
    public void Configure(EntityTypeBuilder<Gpu> builder)
    {
        builder
            .ToTable(TableName);
        
        builder.ComplexProperty(gpu => gpu.Memory, memory =>
        {
            memory
                .Property(m => m.CapacityInGb)
                .HasColumnName("MemoryCapacity");
            
            memory
                .Property(m => m.Type)
                .HasColumnName("MemoryType");
            
            memory
                .Property(m => m.Frequency)
                .HasColumnName("MemoryFrequency");
        });
        
        builder.ComplexProperty(gpu => gpu.ClockSpeed, clockSpeed =>
        {
            clockSpeed
                .Property(c => c.Base)
                .HasColumnName("ClockSpeedBase");
            
            clockSpeed
                .Property(c => c.Boost)
                .HasColumnName("ClockSpeedBoost");
        });
    }
}
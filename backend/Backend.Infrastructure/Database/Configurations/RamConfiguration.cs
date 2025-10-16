using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class RamConfiguration : IEntityTypeConfiguration<Ram>
{
    private const int TimingMaxLength = 20;
    
    public void Configure(EntityTypeBuilder<Ram> builder)
    {
        builder.ComplexProperty(ram => ram.Memory, memory =>
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

        builder
            .Property(ram => ram.Timing)
            .HasMaxLength(TimingMaxLength)
            .IsRequired();
    }
}
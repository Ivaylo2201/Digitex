using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class GraphicsCardConfiguration : IEntityTypeConfiguration<GraphicsCard>
{
    private const string TableName = "GraphicsCards";
    
    public void Configure(EntityTypeBuilder<GraphicsCard> builder)
    {
        builder
            .ToTable(TableName);
        
        builder.ComplexProperty(graphicCard => graphicCard.Memory, memory =>
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
        
        builder.ComplexProperty(graphicCard => graphicCard.ClockSpeed, clockSpeed =>
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
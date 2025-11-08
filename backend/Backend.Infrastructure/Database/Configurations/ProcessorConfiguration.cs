using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class ProcessorConfiguration : IEntityTypeConfiguration<Processor>
{
    private const string TableName = "Processors";
    
    public void Configure(EntityTypeBuilder<Processor> builder)
    {
        builder
            .ToTable(TableName);
        
        builder.ComplexProperty(processor => processor.ClockSpeed, clockSpeed =>
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
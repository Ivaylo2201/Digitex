using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Infrastructure.Database.Configurations;

public class MonitorConfiguration : IEntityTypeConfiguration<Monitor>
{
    public void Configure(EntityTypeBuilder<Monitor> builder)
    {
        builder.ComplexProperty(monitor => monitor.Resolution, resolution =>
        {
            resolution
                .Property(r => r.Width)
                .HasColumnName("ResolutionWidth");
            
            resolution
                .Property(r => r.Height)
                .HasColumnName("ResolutionHeight");
            
            resolution
                .Property(r => r.Type)
                .HasColumnName("ResolutionType");
        });
    }
}
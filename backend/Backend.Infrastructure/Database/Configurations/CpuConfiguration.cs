using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class CpuConfiguration : IEntityTypeConfiguration<Cpu>
{
    public void Configure(EntityTypeBuilder<Cpu> builder)
    {
        builder.ComplexProperty(cpu => cpu.ClockSpeed, clockSpeed =>
        {
            clockSpeed.Property(c => c.Base).HasColumnName("ClockSpeedBase");
            clockSpeed.Property(c => c.Boost).HasColumnName("ClockSpeedBoost");
        });
    }
}
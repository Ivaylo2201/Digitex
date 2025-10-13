using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class StorageConfiguration : IEntityTypeConfiguration<Storage>
{
    public void Configure(EntityTypeBuilder<Storage> builder)
    {
        builder.ComplexProperty(storage => storage.Memory, memory =>
        {
            memory.Property(m => m.CapacityInGb).HasColumnName("MemoryCapacity");
            memory.Property(m => m.Type).HasColumnName("MemoryType");
            memory.Property(m => m.Frequency).HasColumnName("MemoryFrequency");
        });
    }
}
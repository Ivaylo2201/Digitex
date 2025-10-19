using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Database.Configurations;

public class SsdConfiguration : IEntityTypeConfiguration<Ssd>
{
    private const string TableName = "SSDs";
    
    public void Configure(EntityTypeBuilder<Ssd> builder)
    {
        builder
            .ToTable(TableName);

        builder.ComplexProperty(ssd => ssd.OperationSpeed, operationSpeed =>
        {
            operationSpeed
                .Property(o => o.Read)
                .HasColumnName("ReadSpeed");

            operationSpeed
                .Property(o => o.Write)
                .HasColumnName("WriteSpeed");
        });
    }
}
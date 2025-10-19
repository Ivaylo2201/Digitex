using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MemoryType
{
    Ddr4,
    Ddr5,
    GDdr5,
    GDdr6,
    GDdr7
}
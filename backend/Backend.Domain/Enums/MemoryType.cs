using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MemoryType
{
    [JsonStringEnumMemberName("DDR4")]
    Ddr4,

    [JsonStringEnumMemberName("DDR5")]
    Ddr5,

    [JsonStringEnumMemberName("GDDR5")]
    GDdr5,

    [JsonStringEnumMemberName("GDDR6")]
    GDdr6,

    [JsonStringEnumMemberName("GDDR7")]
    GDdr7
}
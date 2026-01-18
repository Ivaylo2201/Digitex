using System.Runtime.Serialization;

namespace Backend.Domain.Enums;

public enum MemoryType
{
    [EnumMember(Value = "DDR4")]
    Ddr4,
    [EnumMember(Value = "DDR5")]
    Ddr5,
    [EnumMember(Value = "GDDR5")]
    GDdr5,
    [EnumMember(Value = "GDDR6")]
    GDdr6,
    [EnumMember(Value = "GDDR7")]
    GDdr7
}
using System.Runtime.Serialization;
namespace Backend.Domain.Enums;

public enum Chipset
{
    [EnumMember(Value = "A620")]
    A620,
    [EnumMember(Value = "B550")]
    B550,
    [EnumMember(Value = "B650")]
    B650,
    [EnumMember(Value = "B760")]
    B760,
    [EnumMember(Value = "B840")]
    B840,
    [EnumMember(Value = "B850")]
    B850,
    [EnumMember(Value = "B860")]
    B860
}

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(StringEnumConverter))]
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

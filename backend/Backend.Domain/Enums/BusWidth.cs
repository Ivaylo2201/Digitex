using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum BusWidth
{
    [EnumMember(Value = "128")]
    Bits128 = 128,
    [EnumMember(Value = "256")]
    Bits256 = 256
}
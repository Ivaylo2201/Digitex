using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum Matrix
{
    [EnumMember(Value = "IPS")]
    Ips,
    [EnumMember(Value = "VA")]
    Va,
    [EnumMember(Value = "TN")]
    Tn
}
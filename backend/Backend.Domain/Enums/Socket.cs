using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum Socket
{
    [EnumMember(Value = "LGA1200")]
    Lga1200,
    [EnumMember(Value = "LGA1700")]
    Lga1700,
    [EnumMember(Value = "AM4")]
    Am4,
    [EnumMember(Value = "AM5")]
    Am5,
}
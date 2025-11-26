using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum Modularity
{
    [EnumMember(Value = "Full")]
    Full,
    [EnumMember(Value = "Semi")]
    Semi,
    [EnumMember(Value = "None")]
    None
}
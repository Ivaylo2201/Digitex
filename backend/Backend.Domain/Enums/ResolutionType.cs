using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum ResolutionType
{
    [EnumMember(Value = "Full HD")]
    Fhd,
    [EnumMember(Value = "4K")]
    Qhd
}
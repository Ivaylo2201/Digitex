using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum FormFactor
{   
    [EnumMember(Value = "ATX")]
    Atx,
    [EnumMember(Value = "Micro ATX")]   
    MicroAtx,
    [EnumMember(Value = "Mini ATX")]
    MiniItx
}
using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FormFactor
{
    [JsonStringEnumMemberName("ATX")]
    Atx,

    [JsonStringEnumMemberName("Micro ATX")]
    MicroAtx,

    [JsonStringEnumMemberName("Mini ATX")]
    MiniItx
}
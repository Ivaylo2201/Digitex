using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

public enum FormFactor
{
    [JsonStringEnumMemberName("ATX")]
    Atx,

    [JsonStringEnumMemberName("Micro ATX")]
    MicroAtx,

    [JsonStringEnumMemberName("Mini ATX")]
    MiniItx
}
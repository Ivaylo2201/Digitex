using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

public enum ResolutionType
{
    [JsonStringEnumMemberName("Full HD")]
    Fhd,

    [JsonStringEnumMemberName("4K")]
    Qhd
}
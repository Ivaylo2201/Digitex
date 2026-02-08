using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ResolutionType
{
    [JsonStringEnumMemberName("Full HD")]
    FullHd,

    [JsonStringEnumMemberName("Quad HD")]
    QuadHd
}
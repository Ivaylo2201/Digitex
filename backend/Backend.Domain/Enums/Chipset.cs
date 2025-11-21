using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Chipset
{
    A620,
    B550,
    B650,
    B760,
    B840,
    B850,
    B860
}

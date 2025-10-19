using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FormFactor
{
    Atx,
    MicroAtx,
    MiniItx
}
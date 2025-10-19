using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Socket
{
    Lga1200,
    Lga1700,
    Am4,
    Am5,
}
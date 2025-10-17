using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Socket
{
    Lga1151,
    Lga1200,
    Lga1700,
    Lga2066,
    Am4,
    Am5,
    Tr4,
    STrx4
}
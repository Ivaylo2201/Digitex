using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

public enum Socket
{
    [JsonStringEnumMemberName("LGA1200")]
    Lga1200,

    [JsonStringEnumMemberName("LGA1700")]
    Lga1700,

    [JsonStringEnumMemberName("AM4")]
    Am4,

    [JsonStringEnumMemberName("AM5")]
    Am5
}
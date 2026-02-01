using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Modularity
{
    [JsonStringEnumMemberName("Full")]
    Full,

    [JsonStringEnumMemberName("Semi")]
    Semi,

    [JsonStringEnumMemberName("None")]
    None
}

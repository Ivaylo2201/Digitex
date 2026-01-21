using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

public enum Modularity
{
    [JsonStringEnumMemberName("Full")]
    Full,

    [JsonStringEnumMemberName("Semi")]
    Semi,

    [JsonStringEnumMemberName("None")]
    None
}

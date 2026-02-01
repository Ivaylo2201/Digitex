using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Matrix
{
    [JsonStringEnumMemberName("IPS")]
    Ips,

    [JsonStringEnumMemberName("VA")]
    Va,

    [JsonStringEnumMemberName("TN")]
    Tn
}
using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

public enum Matrix
{
    [JsonStringEnumMemberName("IPS")]
    Ips,

    [JsonStringEnumMemberName("VA")]
    Va,

    [JsonStringEnumMemberName("TN")]
    Tn
}
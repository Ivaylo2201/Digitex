using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Chipset
{
    [JsonStringEnumMemberName("A620")]
    A620,

    [JsonStringEnumMemberName("B550")]
    B550,

    [JsonStringEnumMemberName("B650")]
    B650,

    [JsonStringEnumMemberName("B760")]
    B760,

    [JsonStringEnumMemberName("B840")]
    B840,

    [JsonStringEnumMemberName("B850")]
    B850,

    [JsonStringEnumMemberName("B860")]
    B860
}
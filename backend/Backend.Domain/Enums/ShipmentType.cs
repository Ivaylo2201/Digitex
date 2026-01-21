using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

public enum ShipmentType
{
    [JsonStringEnumMemberName("Express")]
    Express,

    [JsonStringEnumMemberName("Standard")]
    Standard,

    [JsonStringEnumMemberName("Next Day")]
    NextDay,

    [JsonStringEnumMemberName("Same Day")]
    SameDay
}
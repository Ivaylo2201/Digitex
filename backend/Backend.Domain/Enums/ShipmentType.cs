using System.Runtime.Serialization;

namespace Backend.Domain.Enums;

public enum ShipmentType
{
    [EnumMember(Value = "Express")]
    Express,
    [EnumMember(Value = "Standard")]
    Standard,
    [EnumMember(Value = "Next Day")]
    NextDay,
    [EnumMember(Value = "Same Day")]
    SameDay
}
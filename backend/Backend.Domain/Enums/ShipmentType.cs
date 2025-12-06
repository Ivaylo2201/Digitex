using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum ShipmentType
{
    Express,
    Standard,
    NextDay,
    SameDay
}
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum ShippingType
{
    Express,
    Standard,
    NextDay,
    SameDay
}
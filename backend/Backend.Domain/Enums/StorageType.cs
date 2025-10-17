using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StorageType
{
    Ssd,
    Hdd,
}
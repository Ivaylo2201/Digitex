using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum Role
{
    [EnumMember(Value = "client")]
    Client,
    [EnumMember(Value = "admin")]
    Admin,
    [EnumMember(Value = "manager")]
    Manager
}
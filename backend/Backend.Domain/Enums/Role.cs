using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

public enum Role
{
    [JsonStringEnumMemberName("client")]
    Client,

    [JsonStringEnumMemberName("admin")]
    Admin,

    [JsonStringEnumMemberName("manager")]
    Manager
}
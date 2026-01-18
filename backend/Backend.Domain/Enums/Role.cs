using System.Runtime.Serialization;

namespace Backend.Domain.Enums;

public enum Role
{
    [EnumMember(Value = "client")]
    Client,
    [EnumMember(Value = "admin")]
    Admin,
    [EnumMember(Value = "manager")]
    Manager
}
using System.Runtime.Serialization;

namespace Backend.Domain.Enums;

public enum Modularity
{
    [EnumMember(Value = "Full")]
    Full,
    [EnumMember(Value = "Semi")]
    Semi,
    [EnumMember(Value = "None")]
    None
}
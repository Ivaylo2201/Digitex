using System.Runtime.Serialization;

namespace Backend.Domain.Enums;

public enum Matrix
{
    [EnumMember(Value = "IPS")]
    Ips,
    [EnumMember(Value = "VA")]
    Va,
    [EnumMember(Value = "TN")]
    Tn
}
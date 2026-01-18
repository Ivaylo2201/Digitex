using System.Runtime.Serialization;

namespace Backend.Domain.Enums;

public enum ResolutionType
{
    [EnumMember(Value = "Full HD")]
    Fhd,
    [EnumMember(Value = "4K")]
    Qhd
}
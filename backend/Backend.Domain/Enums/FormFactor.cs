using System.Runtime.Serialization;

namespace Backend.Domain.Enums;

public enum FormFactor
{   
    [EnumMember(Value = "ATX")]
    Atx,
    [EnumMember(Value = "Micro ATX")]   
    MicroAtx,
    [EnumMember(Value = "Mini ATX")]
    MiniItx
}
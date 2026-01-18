using System.Runtime.Serialization;

namespace Backend.Domain.Enums;

public enum StorageInterface
{
    
    [EnumMember(Value = "SATA")]
    Sata,
    [EnumMember(Value = "NVMe")]
    Nvme,
    [EnumMember(Value = "PCIe 4.0")]
    Pcie4,
    [EnumMember(Value = "PCIe 5.0")]
    Pcie5
}
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(StringEnumConverter))]
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
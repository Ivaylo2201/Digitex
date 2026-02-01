using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StorageInterface
{
    [JsonStringEnumMemberName("SATA")]
    Sata,

    [JsonStringEnumMemberName("NVMe")]
    Nvme,

    [JsonStringEnumMemberName("PCIe 4.0")]
    Pcie4,

    [JsonStringEnumMemberName("PCIe 5.0")]
    Pcie5
}
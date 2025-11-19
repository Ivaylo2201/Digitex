﻿using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StorageInterface
{
    Sas,
    Sata,
    Nvme,   
    Pcie4,
    Pcie5
}
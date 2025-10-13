using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;

namespace Backend.Domain.Entities;

public class Storage : ProductBase
{
    public required Memory Memory { get; init; }
    public required StorageType Type { get; init; }
}
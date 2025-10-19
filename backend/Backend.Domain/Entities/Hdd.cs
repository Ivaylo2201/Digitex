using Backend.Domain.Enums;

namespace Backend.Domain.Entities;

public class Hdd : ProductBase
{
    public required int CapacityInTb { get; init; }
    public required int Rpm { get; init; } 
    public required int CacheInMb { get; init; }
    public required InterfaceType Interface { get; init; }
    public required StorageFormFactor FormFactor { get; init; }
}
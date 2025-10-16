using Backend.Domain.Enums;

namespace Backend.Domain.ValueObjects;

public record Memory(int CapacityInGb, MemoryType Type, Frequency Frequency);
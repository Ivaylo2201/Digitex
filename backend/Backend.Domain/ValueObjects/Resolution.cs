using Backend.Domain.Enums;

namespace Backend.Domain.ValueObjects;

public record Resolution(int Width, int Height, ResolutionType Type);
namespace Backend.Domain.ValueObjects;

public record Price
{
    public required double Initial { get; init; }
    public required double Discounted { get; init; }
}
namespace Backend.Domain.ValueObjects;

public record Price
{
    public required decimal Initial { get; init; }
    public required decimal Discounted { get; init; }
}
namespace Backend.Domain.Common;

public record ErrorObject
{
    public required string Message { get; init; }
}
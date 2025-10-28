namespace Backend.Domain.Common;

public record ErrorObject
{
    public required string Message { get; init; }
    public object? Details { get; init; }   
}
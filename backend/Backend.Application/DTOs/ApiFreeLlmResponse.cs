namespace Backend.Application.DTOs;

public record ApiFreeLlmResponse
{
    public required string Response { get; init; }
}
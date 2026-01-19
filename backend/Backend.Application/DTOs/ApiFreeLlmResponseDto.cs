namespace Backend.Application.DTOs;

public record ApiFreeLlmResponseDto
{
    public required string Response { get; init; }
}
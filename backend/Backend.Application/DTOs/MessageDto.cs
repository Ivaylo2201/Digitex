namespace Backend.Application.DTOs;

public record MessageDto
{
    public required string Sender { get; init; }
    public required string Content { get; init; }
}
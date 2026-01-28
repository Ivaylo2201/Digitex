namespace Backend.Application.DTOs;

public record ReviewDto
{
    public required string Comment { get; init; }
    public required int Rating { get; init; }
}
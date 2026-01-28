namespace Backend.Application.DTOs;

public record ReviewDto
{
    public required int Id { get; init; }
    public required string Comment { get; init; }
    public required int Rating { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required string Username { get; init; }
}
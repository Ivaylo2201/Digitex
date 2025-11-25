namespace Backend.Application.Dtos.Review;

public record ReviewDto
{
    public required int Rating { get; init; }
    public string? Comment { get; init; }   
    public required string Username { get; init; }
}
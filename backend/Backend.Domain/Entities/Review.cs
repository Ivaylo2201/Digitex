namespace Backend.Domain.Entities;

public class Review
{
    public int Id { get; init; }
    public required int Rating { get; init; }
    public string? Comment { get; init; }
    public Guid ProductId { get; init; }
    public ProductBase Product { get; init; } = null!;
    public int UserId { get; init; }
    public User User { get; init; } = null!;
    public DateTime CreatedAt { get; init; } = DateTime.Now;
}
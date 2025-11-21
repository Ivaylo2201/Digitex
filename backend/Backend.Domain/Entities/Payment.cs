namespace Backend.Domain.Entities;

public class Payment
{
    public int Id { get; init; }
    public int OrderId { get; init; }
    public Order Order { get; init; } = null!;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}
using Backend.Domain.Enums;

namespace Backend.Domain.Entities;

public class UserToken
{
    public int Id { get; init; }
    public required string Hash { get; init; }
    public int UserId { get; init; }
    public User User { get; init; } = null!;
    public required UserTokenType UserTokenType { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required DateTime ExpiresAt { get; init; }

    public int RemainingTimeOfActivityInMinutes => (int)(ExpiresAt - CreatedAt).TotalMinutes;
    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
}


using Backend.Domain.Enums;

namespace Backend.Domain.Entities;

public class UserToken
{
    private const int AccountVerificationTokenExpirationInMinutes = 1440;
    private const int PasswordResetTokenExpirationInMinutes = 30;
    private const int DefaultTokenExpirationInMinutes = 0;
    
    public int Id { get; init; }
    public required string Hash { get; init; }
    public int UserId { get; init; }
    public User User { get; init; } = null!;
    public required UserTokenType UserTokenType { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required DateTime ExpiresAt { get; init; }

    public int RemainingTimeOfActivityInMinutes => (int)(ExpiresAt - CreatedAt).TotalMinutes;
    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
    
    public static UserToken Create(User user, string hash, UserTokenType userTokenType)
    {
        var createdAt = DateTime.UtcNow;
        var expiresAt = createdAt.AddMinutes(userTokenType switch
        {
            UserTokenType.AccountVerification => AccountVerificationTokenExpirationInMinutes,
            UserTokenType.PasswordReset => PasswordResetTokenExpirationInMinutes,
            _ => DefaultTokenExpirationInMinutes
        });
        
        return new UserToken
        {
            UserId = user.Id,
            Hash = hash,
            UserTokenType = userTokenType,
            CreatedAt = createdAt,
            ExpiresAt = expiresAt
        };
    }
}


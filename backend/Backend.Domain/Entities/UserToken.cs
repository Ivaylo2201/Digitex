using Backend.Domain.Enums;

namespace Backend.Domain.Entities;

public class UserToken
{
    private const int AccountVerificationTokenExpirationInMinutes = 1440;
    private const int PasswordResetTokenExpirationInMinutes = 30; 

    public int Id { get; init; }
    public required string Hash { get; init; }
    public int UserId { get; init; }
    public User User { get; init; } = null!;
    public UserTokenType UserTokenType { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime ExpiresAt { get; init; }
    public bool IsActive => DateTime.UtcNow < ExpiresAt;

    public UserToken(UserTokenType userTokenType)
    {
        UserTokenType = userTokenType;
        CreatedAt = DateTime.UtcNow;
        ExpiresAt = CreatedAt.AddMinutes(userTokenType switch
        {
            UserTokenType.AccountVerification => AccountVerificationTokenExpirationInMinutes,
            UserTokenType.PasswordReset => PasswordResetTokenExpirationInMinutes,
            _ => throw new ArgumentOutOfRangeException(nameof(userTokenType))
        });
    }
}


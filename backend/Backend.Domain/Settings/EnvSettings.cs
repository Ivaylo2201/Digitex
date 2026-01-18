namespace Backend.Domain.Settings;

public record EnvSettings
{
    public required JwtSettings Jwt { get; init; }
    public required MerchantSettings Merchant { get; init; }
    public required SmtpSettings Smtp { get; init; }
    public required CryptographySettings Cryptography { get; init; }
    public required StripeSettings Stripe { get; init; }
    public required AssistantSettings Assistant { get; init; }
}

public record JwtSettings
{
    public required string SecretKey { get; init; }
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
}

public record MerchantSettings
{
    public required string Email { get; init; }
    public required string Username { get; init; }
}

public record SmtpSettings
{
    public required string Provider { get; init; }
    public required int Port { get; init; }
    public required string AppPassword { get; init; }
}

public record CryptographySettings
{
    public required string EncryptionKey { get; init; }
    public required string InitializationVector { get; init; }
}

public record StripeSettings
{
    public required string PublishableKey { get; init; }
    public required string SecretKey { get; init; }
    public required string WebhookSecret { get; init; }
}

public record AssistantSettings
{
    public required string ApiKey { get; init; }
    public required string ApiUrl { get; init; }
}
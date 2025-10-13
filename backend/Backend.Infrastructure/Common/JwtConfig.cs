namespace Backend.Infrastructure.Common;

public record JwtConfig(byte[] Key, string Issuer, string Audience);
namespace Backend.Application.Dtos.Accounts;

public record CompleteAccountVerificationDto
{
    public required string Token { get; init; }
}
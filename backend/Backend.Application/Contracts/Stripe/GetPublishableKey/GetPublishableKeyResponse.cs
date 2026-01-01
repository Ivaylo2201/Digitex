namespace Backend.Application.Contracts.Stripe.GetPublishableKey;

public record GetPublishableKeyResponse
{
    public required string PublishableKey { get; init; }
}
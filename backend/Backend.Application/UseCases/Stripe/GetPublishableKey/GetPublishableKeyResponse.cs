namespace Backend.Application.UseCases.Stripe.GetPublishableKey;

public record GetPublishableKeyResponse
{
    public required string PublishableKey { get; init; }
}
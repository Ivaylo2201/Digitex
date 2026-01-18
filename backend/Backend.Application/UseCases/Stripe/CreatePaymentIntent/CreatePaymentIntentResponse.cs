namespace Backend.Application.UseCases.Stripe.CreatePaymentIntent;

public record CreatePaymentIntentResponse
{
    public required string ClientSecret { get; init; }
}
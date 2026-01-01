namespace Backend.Application.Contracts.Stripe.CreatePaymentIntent;

public record CreatePaymentIntentResponse
{
    public string? ClientSecret { get; init; }
}
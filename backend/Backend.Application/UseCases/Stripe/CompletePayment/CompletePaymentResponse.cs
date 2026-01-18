namespace Backend.Application.UseCases.Stripe.CompletePayment;

public record CompletePaymentResponse
{
    public required string Message { get; init; }
}
using Backend.Domain.Common;
using MediatR;
using Microsoft.Extensions.Primitives;

namespace Backend.Application.UseCases.Stripe.CompletePayment;

public record CompletePaymentRequest : IRequest<Result<CompletePaymentResponse>>
{
    public required Stream Payload { get; init; }
    public required IDictionary<string, StringValues> Headers { get; init; }
}
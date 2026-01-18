using Backend.Domain.Common;
using Backend.Infrastructure.Common;
using MediatR;

namespace Backend.Application.UseCases.Stripe.CreatePaymentIntent;

public record CreatePaymentIntentRequest : IRequest<Result<CreatePaymentIntentResponse>>, IAuthorized
{
    public int UserId { get; set; }
}
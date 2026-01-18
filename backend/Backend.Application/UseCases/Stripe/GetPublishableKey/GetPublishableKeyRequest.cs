using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Stripe.GetPublishableKey;

public record GetPublishableKeyRequest : IRequest<Result<GetPublishableKeyResponse>>;
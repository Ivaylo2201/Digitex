using System.Net;
using Backend.Application.Extensions;
using Backend.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Stripe.GetPublishableKey;

public class GetPublishableKeyRequestHandler(
    ILogger<GetPublishableKeyRequestHandler> logger) : IRequestHandler<GetPublishableKeyRequest, Result<GetPublishableKeyResponse>>
{
    public Task<Result<GetPublishableKeyResponse>> Handle(GetPublishableKeyRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<GetPublishableKeyResponse>.Success(HttpStatusCode.OK, new GetPublishableKeyResponse
        {
            PublishableKey = "STRIPE_PUBLISHABLE_KEY".GetRequiredEnvironmentVariable()
        }));
    }
}
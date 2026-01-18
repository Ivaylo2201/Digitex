using System.Net;
using Backend.Domain.Common;
using Backend.Domain.Settings;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Backend.Application.UseCases.Stripe.GetPublishableKey;

public class GetPublishableKeyRequestHandler(
    ILogger<GetPublishableKeyRequestHandler> logger,
    IOptions<EnvSettings> options) : IRequestHandler<GetPublishableKeyRequest, Result<GetPublishableKeyResponse>>
{
    public Task<Result<GetPublishableKeyResponse>> Handle(GetPublishableKeyRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<GetPublishableKeyResponse>.Success(HttpStatusCode.OK, new GetPublishableKeyResponse
        {
            PublishableKey = options.Value.Stripe.PublishableKey
        }));
    }
}
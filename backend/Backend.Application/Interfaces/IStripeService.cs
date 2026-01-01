using Backend.Domain.Common;
using Microsoft.Extensions.Primitives;

namespace Backend.Application.Interfaces;

public interface IStripeService
{
    Task<Result> ProcessWebhookAsync(string json, IDictionary<string, StringValues> headers, CancellationToken cancellationToken = default);
    Task<Result<string>> CreatePaymentIntentAsync(int userId, CancellationToken cancellationToken = default);
}
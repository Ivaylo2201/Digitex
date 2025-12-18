using Backend.Domain.Common;
using Microsoft.Extensions.Primitives;

namespace Backend.Application.Interfaces.Services;

public interface IStripeService
{
    Task<Result> ProcessWebhookAsync(string json, IDictionary<string, StringValues> headers, CancellationToken stoppingToken = default);
    Task<Result<string>> CreatePaymentIntentAsync(int userId, CancellationToken stoppingToken = default);
}
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Stripe;

namespace Backend.Infrastructure.Services.Common;

public class PaymentService(ILogger<PaymentService> logger, IUserRepository userRepository, ICartRepository cartRepository) : IPaymentService
{
    private const string Source = nameof(PaymentService);
    private const string WebhookSecretEnv = "WebhookSecret";
    private const string SuccessEventType = "payment_intent.succeeded";
    private const string StripeSignatureKey = "Stripe-Signature";
    private const string EuroCurrencyCode = "eur";
    private readonly List<string> _paymentMethodTypes = ["card"];
    
    public async Task<Result> ProcessWebhookAsync(string json, IDictionary<string, StringValues> headers, CancellationToken stoppingToken = default)
    {
        var webhookSecret = Environment.GetEnvironmentVariable(WebhookSecretEnv);

        if (webhookSecret is null)
        {
            logger.LogError("[{Source}]: Improperly configured webhook secret in env.", Source);
            return Result.Failure(ErrorType.InvalidWebhookSecret, StatusCodes.Status500InternalServerError);
        }

        try
        {
            var stripeSignature = headers[StripeSignatureKey];
            
            logger.LogInformation("[{Source}]: Constructing Stripe event using JSON={Json} and stripeSignature={StripeSignature}...", Source, json, stripeSignature);
            var stripeEvent = EventUtility.ConstructEvent(json, stripeSignature, webhookSecret);

            if (stripeEvent?.Type is SuccessEventType)
            {
                if (stripeEvent.Data.Object is not PaymentIntent paymentIntent)
                {
                    logger.LogError("[{Source}]: Could not cast Stripe event into a PaymentIntent.", Source);
                    return Result.Failure(ErrorType.General, StatusCodes.Status500InternalServerError);
                }
                
                if (!paymentIntent.Metadata.TryGetValue("userId", out var userIdValue) || !int.TryParse(userIdValue, out var userId))
                {
                    logger.LogError("[{Source}]: Missing userId in Metadata.", Source);
                    return Result.Failure(ErrorType.General, StatusCodes.Status500InternalServerError);
                }

                var user = await userRepository.GetOneWithItemsAndProductsAsync(userId, stoppingToken);
                
                // For each item in user.Cart.Items, reduce the stock of the product by the quantity of the item and create a sale object
                // Clear the cart
                // Send a thank you email
                
                return Result.Success();
            }
            
            logger.LogError("[{Source}]: Event type was not {SuccessEventType}.", Source, SuccessEventType);
            return Result.Failure(ErrorType.PaymentFailed, StatusCodes.Status402PaymentRequired);
        }
        catch (Exception ex)
        {
            logger.LogError("[{Source}]: Failed to process webhook call from Stripe. Exception message - {Exception}", Source, ex.Message);
            return Result.Failure(ErrorType.General, StatusCodes.Status400BadRequest);
        }
    }

    public async Task<Result<string>> CreatePaymentIntentAsync(int userId, CancellationToken stoppingToken = default)
    {
        var cartTotal = await cartRepository.GetCartTotalAsync(userId, stoppingToken);
        var paymentIntentService = new PaymentIntentService();

        try
        {
            var paymentIntentOptions = new PaymentIntentCreateOptions
            {
                Amount = (long)cartTotal * 100,
                Currency = EuroCurrencyCode,
                PaymentMethodTypes = _paymentMethodTypes,
                Metadata = new Dictionary<string, string>
                {
                    { "userId", userId.ToString() }
                }
            };
            
            logger.LogInformation("[{Source}]: Creating payment intent...", Source);
            
            var paymentIntent = await paymentIntentService.CreateAsync(
                paymentIntentOptions,
                cancellationToken: stoppingToken);
            
            return Result<string>.Success(paymentIntent.ClientSecret);
        }
        catch (Exception ex)
        {
            logger.LogError("[{Source}]: Failed to create payment intent. Exception message - {Exception}", Source, ex.Message);
            return Result<string>.Failure(ErrorType.General);
        }
    }
}
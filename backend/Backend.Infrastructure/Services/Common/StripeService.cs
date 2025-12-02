using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Exceptions;
using Backend.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Stripe;

namespace Backend.Infrastructure.Services.Common;

public class StripeService(
    ILogger<StripeService> logger,
    IEmailSendingService emailSendingService,
    IUserRepository userRepository,
    ICartRepository cartRepository) : IStripeService
{
    private const string Source = nameof(StripeService);
    private const string WebhookSecretEnv = "WebhookSecret";
    private const string SuccessEventType = "payment_intent.succeeded";
    private const string StripeSignatureKey = "Stripe-Signature";
    private const string EuroCurrencyCode = "eur";
    private readonly List<string> _paymentMethodTypes = ["card"];
    
    public async Task<Result> ProcessWebhookAsync(string json, IDictionary<string, StringValues> headers, CancellationToken stoppingToken = default)
    {
        var webhookSecret = Environment.GetEnvironmentVariable(WebhookSecretEnv);

        if (webhookSecret is null)
            throw new ImproperlyConfiguredException("Webhook secret is not configured.");

        try
        {
            var stripeSignature = headers[StripeSignatureKey];
            
            logger.LogInformation("[{Source}]: Constructing Stripe event using Json={Json} and StripeSignature={StripeSignature}...", Source, json, stripeSignature);
            var stripeEvent = EventUtility.ConstructEvent(json, stripeSignature, webhookSecret);

            if (stripeEvent?.Type is not SuccessEventType)
            {
                logger.LogError("[{Source}]: Event type was not {SuccessEventType}.", Source, SuccessEventType);
                return Result.Failure(StatusCodes.Status402PaymentRequired, ErrorType.PaymentFailed);
            }

            if (stripeEvent.Data.Object is not PaymentIntent paymentIntent)
            {
                logger.LogError("[{Source}]: Could not cast Stripe event into a PaymentIntent.", Source);
                return Result.Failure(StatusCodes.Status500InternalServerError);
            }
                
            if (!paymentIntent.Metadata.TryGetValue("userId", out var userIdValue) || !int.TryParse(userIdValue, out var userId))
            {
                logger.LogError("[{Source}]: Missing userId in Metadata.", Source);
                return Result.Failure(StatusCodes.Status400BadRequest);
            }

            //var user = await userRepository.GetOneWithItemsAndProductsAsync(userId, stoppingToken);
                
            // For each item in user.Cart.Items, reduce the stock of the product by the quantity of the item and create a sale object
            // Clear the cart

            //await emailSendingService.SendOrderConfirmationEmailAsync(user, stoppingToken);
                
            return Result.Success(StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            logger.LogError("[{Source}]: Failed to process webhook call from Stripe. Exception message - {Exception}", Source, ex.Message);
            return Result.Failure(StatusCodes.Status400BadRequest);
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
            
            return Result<string>.Success(StatusCodes.Status200OK, paymentIntent.ClientSecret);
        }
        catch (Exception ex)
        {
            logger.LogError("[{Source}]: Failed to create payment intent. Exception message - {Exception}", Source, ex.Message);
            return Result<string>.Failure(StatusCodes.Status400BadRequest, ErrorType.General);
        }
    }
}
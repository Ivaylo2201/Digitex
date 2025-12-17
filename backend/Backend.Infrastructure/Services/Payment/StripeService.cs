using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Stripe;

namespace Backend.Infrastructure.Services.Payment;

public class StripeService(
    ILogger<StripeService> logger,
    IEmailSenderService emailSenderService,
    IUserRepository userRepository,
    ICartRepository cartRepository) : IStripeService
{
    private const string Source = nameof(StripeService);
    private const string PaymentIntentSucceeded = "payment_intent.succeeded";
    
    public async Task<Result> ProcessWebhookAsync(string json, IDictionary<string, StringValues> headers, CancellationToken stoppingToken = default)
    {
        var webhookSecret = "WebhookSecret".GetRequiredEnvironmentVariable();

        try
        {
            var stripeEvent = EventUtility.ConstructEvent(json, headers["Stripe-Signature"], webhookSecret);

            if (stripeEvent?.Type is not PaymentIntentSucceeded)
            {
                logger.LogError("[{Source}]: Event type was not {PaymentIntentSucceeded}.", Source, PaymentIntentSucceeded);
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

            //await emailSenderService.SendOrderConfirmationEmailAsync(user, stoppingToken);
                
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
                Currency = "eur",
                PaymentMethodTypes = ["card"],
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
using System.Net;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;
using Backend.Domain.Settings;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stripe;

namespace Backend.Application.UseCases.Stripe.CompletePayment;

public class CompletePaymentRequestHandler(
    ILogger<CompletePaymentRequestHandler> logger,
    IOptions<EnvSettings> options,
    IUserRepository userRepository,
    IEmailSenderService emailSenderService) : IRequestHandler<CompletePaymentRequest, Result<CompletePaymentResponse>>
{
    private const string Source = nameof(CompletePaymentRequestHandler);
    private const string PaymentIntentSucceeded = "payment_intent.succeeded";
    
    public async Task<Result<CompletePaymentResponse>> Handle(CompletePaymentRequest request, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(request.Payload);
        var json = await reader.ReadToEndAsync(cancellationToken);
        
        try
        {
            var stripeEvent = EventUtility.ConstructEvent(
                json,
                request.Headers["Stripe-Signature"],
                options.Value.Stripe.WebhookSecret);

            if (stripeEvent?.Type is not PaymentIntentSucceeded)
            {
                logger.LogError("[{Source}]: Event type was not {PaymentIntentSucceeded}.", Source, PaymentIntentSucceeded);
                return Result<CompletePaymentResponse>.Failure(HttpStatusCode.PaymentRequired);
            }

            if (stripeEvent.Data.Object is not PaymentIntent paymentIntent)
            {
                logger.LogError("[{Source}]: Could not cast Stripe event into a PaymentIntent.", Source);
                return Result<CompletePaymentResponse>.Failure(HttpStatusCode.InternalServerError);
            }
                
            if (!paymentIntent.Metadata.TryGetValue("userId", out var userIdValue) || !int.TryParse(userIdValue, out var userId))
            {
                logger.LogError("[{Source}]: Missing userId in Metadata.", Source);
                return Result<CompletePaymentResponse>.Failure(HttpStatusCode.BadRequest);
            }

            //var user = await userRepository.GetOneWithItemsAndProductsAsync(userId, stoppingToken);
                
            // For each item in user.Cart.Items, reduce the stock of the product by the quantity of the item and create a sale object
            // Clear the cart

            //await emailSenderService.SendOrderConfirmationEmailAsync(user, stoppingToken);
                
            return Result<CompletePaymentResponse>.Success(HttpStatusCode.OK, new CompletePaymentResponse
            {
                Message = "Payment completed successfully."
            });
        }
        catch (Exception ex)
        {
            logger.LogError("[{Source}]: Failed to process webhook call from Stripe. Exception message - {Exception}", Source, ex.Message);
            return Result<CompletePaymentResponse>.Failure(HttpStatusCode.BadRequest);
        }
    }
}
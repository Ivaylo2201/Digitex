using System.Net;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
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
    IProductBaseRepository productBaseRepository,
    ISaleRepository saleRepository,
    IOrderRepository orderRepository,
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
            
            if (!paymentIntent.Metadata.TryGetValue("shipmentId", out var shipmentIdValue) || !int.TryParse(shipmentIdValue, out var shipmentId))
            {
                logger.LogError("[{Source}]: Missing shipmentId in Metadata.", Source);
                return Result<CompletePaymentResponse>.Failure(HttpStatusCode.BadRequest);
            }
            
            var user = await userRepository.GetOneAsync(userId, cancellationToken);

            if (user is null)
            {
                logger.LogError("[{Source}]: User not found.", Source);
                return Result<CompletePaymentResponse>.Failure(HttpStatusCode.NotFound);
            }

            foreach (var item in user.Cart.Items)
            {
                await productBaseRepository.ReduceQuantityAsync(item.Product.Id, item.Quantity, cancellationToken);
                
                await saleRepository.CreateAsync(
                    new Sale { ProductId = item.ProductId, QuantitySold =  item.Quantity },
                    cancellationToken);
            }

            var order = await orderRepository.CreateAsync(user.Id, shipmentId, user.Cart.Items, cancellationToken);
            await emailSenderService.SendOrderConfirmationEmailAsync(user, order, cancellationToken);
                
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
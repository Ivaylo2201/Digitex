using System.Net;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Stripe;

namespace Backend.Application.UseCases.Stripe.CreatePaymentIntent;

public class CreatePaymentIntentRequestHandler(
    ILogger<CreatePaymentIntentRequestHandler> logger,
    ICartRepository cartRepository,
    IShipmentRepository shipmentRepository) : IRequestHandler<CreatePaymentIntentRequest, Result<CreatePaymentIntentResponse>>
{
    private const string Source = nameof(CreatePaymentIntentRequestHandler);

    public async Task<Result<CreatePaymentIntentResponse>> Handle(CreatePaymentIntentRequest request, CancellationToken cancellationToken)
    {
        var cart = await cartRepository.GetCartAsync(request.UserId, cancellationToken);

        if (cart is null || cart.Items.Count is 0)
            return Result<CreatePaymentIntentResponse>.Failure(HttpStatusCode.BadRequest);
        
        var paymentIntentService = new PaymentIntentService();

        try
        {
            var shipment = await shipmentRepository.GetOneAsync(request.ShipmentId, cancellationToken);
            
            var paymentIntentOptions = new PaymentIntentCreateOptions
            {
                Amount = (long)((cart.Items.Sum(item => item.Price) + shipment?.Cost ?? 0) * 100),
                Currency = "eur",
                PaymentMethodTypes = ["card"],
                Metadata = new Dictionary<string, string>
                {
                    { "userId", request.UserId.ToString() },
                    { "shipmentId", request.ShipmentId.ToString() },
                    { "countryId", request.CountryId.ToString() },
                    { "cityId", request.CityId.ToString() },
                    { "streetName", request.StreetName },
                    { "streetNumber", request.StreetNumber.ToString() },
                    { "floor", request.Floor?.ToString() ?? "" },
                    { "apartmentNumber", request.ApartmentNumber?.ToString() ?? "" }
                }
            };

            logger.LogInformation("[{Source}]: Creating payment intent...", Source);

            var paymentIntent = await paymentIntentService.CreateAsync(
                paymentIntentOptions,
                cancellationToken: cancellationToken);

            return Result<CreatePaymentIntentResponse>.Success(HttpStatusCode.OK, new CreatePaymentIntentResponse
            {
                ClientSecret = paymentIntent.ClientSecret
            });
        }
        catch (Exception ex)
        {
            logger.LogError("[{Source}]: Failed to create payment intent. Exception message - {Exception}", Source, ex.Message);
            return Result<CreatePaymentIntentResponse>.Failure(HttpStatusCode.BadRequest);
        }
    }
}
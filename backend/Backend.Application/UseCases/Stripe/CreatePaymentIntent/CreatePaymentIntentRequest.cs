using Backend.Application.Interfaces.Common;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Stripe.CreatePaymentIntent;

public record CreatePaymentIntentRequest : IRequest<Result<CreatePaymentIntentResponse>>, IAuthorized
{
    public int UserId { get; set; }
    public required int ShipmentId { get; init; }
    public required int CountryId { get; init; }
    public required int CityId { get; init; }
    public required string StreetName { get; init; }
    public required int StreetNumber { get; init; }
    public int? Floor { get; init; }
    public int? ApartmentNumber { get; init; }
}

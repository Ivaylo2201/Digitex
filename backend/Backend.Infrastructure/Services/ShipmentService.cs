using Backend.Application.Contracts.Shipment;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Services;

public class ShipmentService(IShipmentRepository shipmentRepository, ICurrencyService currencyService, IExchangeRepository exchangeRepository) : IShipmentService
{
    public async Task<Result<IReadOnlyList<ShipmentDto>>> GetShipmentsAsync(CurrencyIsoCode currencyIsoCode, CancellationToken cancellationToken = default)
    {
        var shipments = await shipmentRepository.ListAllAsync(cancellationToken: cancellationToken);
        var rate = await exchangeRepository.GetRateAsync(CurrencyIsoCode.Eur, currencyIsoCode, cancellationToken);
        
        var projections = currencyService
            .ConvertPrices(shipments, shipment => shipment.Cost *= rate)
            .Adapt<IReadOnlyList<ShipmentDto>>();
        
        return Result<IReadOnlyList<ShipmentDto>>.Success(StatusCodes.Status200OK, projections);   
    }
}
using Backend.Application.CQRS.Shipping.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Shipping.Handlers;

using Shipping = Domain.Entities.Shipping;

public class GetAllShippingsQueryHandler(
    ILogger<GetAllShippingsQueryHandler> logger,
    IShippingRepository shippingRepository) : IQueryHandler<GetAllShippingsQuery, Result<IEnumerable<Shipping>>>
{
    public async Task<Result<IEnumerable<Shipping>>> HandleAsync(GetAllShippingsQuery request, CancellationToken cancellationToken)
    {
        return Result<IEnumerable<Shipping>>.Success(await shippingRepository.GetAllAsync());
    }
}
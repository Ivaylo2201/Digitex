using Backend.Application.CQRS.Shipping.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Shipping.Handlers;

using Shipping = Domain.Entities.Shipping;

public class ListShippingsQueryHandler(
    ILogger<ListShippingsQueryHandler> logger,
    IShippingRepository shippingRepository) : IQueryHandler<ListShippingsQuery, Result<IEnumerable<Shipping>>>
{
    public async Task<Result<IEnumerable<Shipping>>> HandleAsync(ListShippingsQuery request, CancellationToken cancellationToken)
    {
        return Result<IEnumerable<Shipping>>.Success(await shippingRepository.ListAllAsync());
    }
}
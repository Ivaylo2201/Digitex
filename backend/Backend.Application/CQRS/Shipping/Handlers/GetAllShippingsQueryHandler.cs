using Backend.Application.CQRS.Shipping.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;

namespace Backend.Application.CQRS.Shipping.Handlers;

using Shipping = Domain.Entities.Shipping;

public class GetAllShippingsQueryHandler(IShippingRepository shippingRepository) : IRequestHandler<GetAllShippingsQuery, Result<IEnumerable<Shipping>>>
{
    public async Task<Result<IEnumerable<Shipping>>> Handle(GetAllShippingsQuery request, CancellationToken cancellationToken)
    {
        return Result<IEnumerable<Shipping>>.Success(await shippingRepository.GetAllAsync());
    }
}
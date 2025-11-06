using Backend.Application.DTOs.Shipping;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Services;

public interface IShippingService
{
    Task<Result<List<ShippingDto>>> ListAllAsync(CancellationToken cancellationToken = default);
}
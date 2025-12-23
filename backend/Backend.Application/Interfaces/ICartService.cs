using Backend.Application.Dtos.Cart;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces;

public interface ICartService
{
    Task<Result> AddToCartAsync(AddToCartDto body, CancellationToken stoppingToken);
}
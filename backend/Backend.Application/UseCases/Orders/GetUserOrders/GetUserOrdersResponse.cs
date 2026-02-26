using Backend.Application.DTOs;

namespace Backend.Application.UseCases.Orders.GetUserOrders;

public record GetUserOrdersResponse
{
    public required IEnumerable<OrderDto> Orders { get; init; } = [];
}
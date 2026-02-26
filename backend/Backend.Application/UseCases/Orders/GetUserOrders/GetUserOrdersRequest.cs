using Backend.Application.Interfaces.Common;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Orders.GetUserOrders;

public record GetUserOrdersRequest : IRequest<Result<GetUserOrdersResponse>>, IAuthorized
{
    public int UserId { get; set; }
}
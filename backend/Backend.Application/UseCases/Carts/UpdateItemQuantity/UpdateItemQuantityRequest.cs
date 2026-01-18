using Backend.Domain.Common;
using Backend.Infrastructure.Common;
using MediatR;

namespace Backend.Application.UseCases.Carts.UpdateItemQuantity;

public record UpdateItemQuantityRequest : IRequest<Result<UpdateItemQuantityResponse>>, IAuthorized
{
    public int UserId { get; set; }
    public int ItemId { get; set; }
    public required int NewQuantity { get; init; }
}
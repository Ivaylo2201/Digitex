using Backend.Application.Interfaces.Common;
using Backend.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.UseCases.Products;

public record CreateRequestBase : IRequest<Result<Unit>>, ICreateRequest
{
    public required int BrandId { get; init; }
    public required string ModelName { get; init; }
    public required decimal InitialPrice { get; set; }
    public int DiscountPercentage { get; init; }
    public required int Quantity { get; set; }
    public required IFormFile Image { get; init; }
}
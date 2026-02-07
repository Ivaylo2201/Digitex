using Backend.Application.Interfaces.Common;
using Backend.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.UseCases.Products;

public record UpdateRequestBase : IRequest<Result<Unit>>, IUpdateRequest
{
    public Guid Id { get; set; }
    public required int BrandId { get; init; }
    public required string ModelName { get; init; }
    public required decimal Price { get; set; }
    public int DiscountPercentage { get; init; }
    public required int Quantity { get; set; }
    public IFormFile? Image { get; init; }
}
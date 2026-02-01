using Backend.Application.Interfaces.Common;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Products;

public record GetAllProductsRequestBase<TProjection> : IRequest<Result<Pagination<TProjection>>>, IGetAllRequest
{
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string Currency { get; init; } = "EUR";
    public IDictionary<string, string> Criteria { get; init; } = new Dictionary<string, string>();
}

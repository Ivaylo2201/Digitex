using Backend.Application.Interfaces.Common;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using MediatR;

namespace Backend.Application.UseCases.Products;

public record GetOneProductRequestBase<TProjection> : IRequest<Result<TProjection?>>, IGetOneRequest
{
    public required Guid Id { get; init; }
    public required CurrencyIsoCode Currency { get; init; }
}
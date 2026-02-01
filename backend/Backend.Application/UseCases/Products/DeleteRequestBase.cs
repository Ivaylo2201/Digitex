using Backend.Application.Interfaces.Common;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Products;

public record DeleteRequestBase : IRequest<Result<Unit>>, IDeleteRequest
{
    public required Guid Id { get; init; }
}
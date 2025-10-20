using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.CQRS;

public abstract record GetAllQueryBase<TEntity> : IRequest<Result<IEnumerable<TEntity>>>;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.CQRS;

public abstract record GetOneQueryBase<TEntity, TKey>(TKey Id) : IRequest<Result<TEntity?>>;
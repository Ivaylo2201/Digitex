using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.CQRS.Ssd.Queries;

using Ssd = Domain.Entities.Ssd;

public record GetOneSsdQuery(Guid Id) : IRequest<Result<Ssd?>>;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.CQRS.Ssd.Queries;

using Ssd = Domain.Entities.Ssd;

public record GetAllSsdsQuery : IRequest<Result<IEnumerable<Ssd>>>;
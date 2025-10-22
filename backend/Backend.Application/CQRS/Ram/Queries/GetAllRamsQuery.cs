using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.CQRS.Ram.Queries;

using Ram = Domain.Entities.Ram;

public record GetAllRamsQuery : IRequest<Result<IEnumerable<Ram>>>;
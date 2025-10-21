using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.CQRS.Motherboard.Queries;

using Motherboard = Domain.Entities.Motherboard;

public record GetOneMotherboardQuery(Guid Id) : IRequest<Result<Motherboard?>>;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.CQRS.Cpu.Queries;

using Cpu = Domain.Entities.Cpu;

public record GetOneCpuQuery(Guid Id) : IRequest<Result<Cpu?>>;
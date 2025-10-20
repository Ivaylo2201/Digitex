using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.CQRS.Cpu.Queries.GetAllCpus;

using Cpu = Domain.Entities.Cpu;

public record GetAllCpusQuery : IRequest<Result<IEnumerable<Cpu>>>;
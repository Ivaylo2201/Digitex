using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Cpu.Queries;

using Cpu = Domain.Entities.Cpu;

public class GetAllCpusQuery : Query<Result<IEnumerable<Cpu>>>;
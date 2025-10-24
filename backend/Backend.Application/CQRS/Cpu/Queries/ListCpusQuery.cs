using Backend.Application.CQRS.Generic.Queries;

namespace Backend.Application.CQRS.Cpu.Queries;

using Cpu = Domain.Entities.Cpu;

public class ListCpusQuery : ListEntitiesQuery<Cpu>;
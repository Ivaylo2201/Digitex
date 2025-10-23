using Backend.Application.Generic;

namespace Backend.Application.CQRS.Cpu.Queries;

using Cpu = Domain.Entities.Cpu;

public class ListAllCpusQuery : ListEntitiesQuery<Cpu>;
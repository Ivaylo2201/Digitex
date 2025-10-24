using Backend.Application.CQRS.Generic.Queries;

namespace Backend.Application.CQRS.Ram.Queries;

using Ram = Domain.Entities.Ram;

public class GetRamQuery : GetEntityQuery<Ram, Guid>;
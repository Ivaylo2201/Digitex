using Backend.Application.CQRS.Generic.Queries;

namespace Backend.Application.CQRS.Motherboard.Queries;

using Motherboard = Domain.Entities.Motherboard;

public class GetMotherboardQuery : GetEntityQuery<Motherboard, Guid>;
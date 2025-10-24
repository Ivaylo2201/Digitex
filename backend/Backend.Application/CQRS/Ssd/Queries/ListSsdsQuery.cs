using Backend.Application.Generic.Queries;

namespace Backend.Application.CQRS.Ssd.Queries;

using Ssd = Domain.Entities.Ssd;

public class ListSsdsQuery : ListEntitiesQuery<Ssd>;
using Backend.Application.Generic.Queries;

namespace Backend.Application.CQRS.Gpu.Queries;

using Gpu = Domain.Entities.Gpu;

public class ListGpusQuery : ListEntitiesQuery<Gpu>;
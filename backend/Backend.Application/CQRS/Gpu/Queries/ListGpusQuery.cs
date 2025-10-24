using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Gpu.Queries;

using Gpu = Domain.Entities.Gpu;

public class ListGpusQuery : Query<Result<IEnumerable<Gpu>>>;
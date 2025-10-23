using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Motherboard.Queries;

using Motherboard = Domain.Entities.Motherboard;

public class GetAllMotherboardsQuery : Query<Result<IEnumerable<Motherboard>>>;
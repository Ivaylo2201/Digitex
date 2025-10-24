using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Motherboard.Queries;

using Motherboard = Domain.Entities.Motherboard;

public class ListMotherboardsQuery : Query<Result<IEnumerable<Motherboard>>>;
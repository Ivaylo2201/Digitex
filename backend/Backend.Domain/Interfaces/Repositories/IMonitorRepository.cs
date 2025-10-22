using Backend.Domain.Interfaces.Generics;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Domain.Interfaces.Repositories;

public interface IMonitorRepository : IReadable<Monitor, Guid>;
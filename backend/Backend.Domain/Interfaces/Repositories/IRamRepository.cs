using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces.Repositories;

public interface IRamRepository : ISingleReadable<Ram, Guid>, IMultipleReadable<Ram>;
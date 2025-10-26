using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces.Repositories;

public interface ISsdRepository : ISingleReadable<Ssd, Guid>, IMultipleReadable<Ssd>;
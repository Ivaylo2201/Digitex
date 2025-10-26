using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces.Repositories;

public interface ICpuRepository : ISingleReadable<Cpu, Guid>, IMultipleReadable<Cpu>;
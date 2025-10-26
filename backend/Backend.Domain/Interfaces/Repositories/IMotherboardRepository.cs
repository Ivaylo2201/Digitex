using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces.Repositories;

public interface IMotherboardRepository : ISingleReadable<Motherboard, Guid>, IMultipleReadable<Motherboard>;
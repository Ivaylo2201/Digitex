using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces.Repositories;

public interface IMotherboardRepository
{
    Task<Motherboard?> GetOneAsync(Guid id);
    Task<IEnumerable<Motherboard>> GetAllAsync();
}
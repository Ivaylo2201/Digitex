using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces.Repositories;

public interface ICpuRepository
{
    Task<Cpu?> GetOneAsync(Guid id);
    Task<IEnumerable<Cpu>> GetAllAsync();
}
using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces.Repositories;

public interface IAddressRepository
{
    Task<Address> GetOrCreateAsync();
}
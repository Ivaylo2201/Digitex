using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces.Repositories;

public interface ICityRepository
{
    Task<List<City>> GetAllByCountryId(int countryId, CancellationToken cancellationToken);
}
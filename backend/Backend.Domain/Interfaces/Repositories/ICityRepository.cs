using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces;

public interface ICityRepository
{
    Task<List<City>> GetAllByCountryId(int countryId, CancellationToken cancellationToken);
}
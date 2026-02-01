using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories.Generics;

namespace Backend.Domain.Interfaces.Repositories;

public interface IBrandRepository : IMultipleReadable<Brand>
{
    Task<List<string>> ListBrandNamesAsync<TProduct>(CancellationToken stoppingToken = default) where TProduct : ProductBase;
}
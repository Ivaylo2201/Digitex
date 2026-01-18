using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces;

public interface IBrandRepository
{
    Task<List<string>> ListBrandNamesAsync<TProduct>(CancellationToken stoppingToken = default) where TProduct : ProductBase;
}
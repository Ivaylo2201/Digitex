using System.Linq.Expressions;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories.Products;

public abstract class ProductRepositoryBase<TProduct>(DatabaseContext context) : IProductRepository<TProduct> where TProduct : ProductBase
{
    public async Task<TProduct?> GetOneAsync(Guid id, CancellationToken stoppingToken)
    {
        return await context
            .Set<TProduct>()
            .AsNoTracking()
            .Include(product => product.Brand)
            .Include(product => product.Suggestions)
            .ThenInclude(suggestion => suggestion.Brand)
            .Include(product => product.Reviews)
            .ThenInclude(review => review.User)
            .FirstOrDefaultAsync(product => product.Id == id, stoppingToken);
    }

    public async Task<TProduct> CreateAsync(TProduct product, CancellationToken cancellationToken)
    {
        var entity = (await context.Set<TProduct>().AddAsync(product, cancellationToken)).Entity;
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<TProduct>> GetAllAsync(int page, int pageSize, Expression<Func<TProduct, bool>> filter, CancellationToken cancellationToken)
    {
        var queryable = context
            .Set<TProduct>()
            .OrderBy(product => product.Id)
            .AsNoTracking()
            .Include(product => product.Reviews)
            .Include(p => p.Brand)
            .Where(p => p.Quantity > 0)
            .Where(filter);

        return await queryable
            .Skip((Math.Max(page, 1) - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(Expression<Func<TProduct, bool>> filter, CancellationToken cancellationToken)
        => await context.Set<TProduct>().CountAsync(filter, cancellationToken);

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await context.Set<TProduct>().FirstOrDefaultAsync(product => product.Id == id, cancellationToken);
        
        if (product is null)
            return;
        
        context.Set<TProduct>().Remove(product);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Guid id, TProduct item, CancellationToken cancellationToken)
    {
        var product = await context.Set<TProduct>().FirstOrDefaultAsync(graphicsCard => graphicsCard.Id == id, cancellationToken);

        if (product is null)
            return;
        
        item.Id = product.Id;
        var entry = context.Entry(product);
        
        foreach (var property in entry.Metadata.GetProperties())
        {
            var newValue = item.GetType()
                .GetProperty(property.Name)?
                .GetValue(item);

            if (newValue is not null)
            {
                entry.Property(property.Name).CurrentValue = newValue;
            }
        }

        
        await context.SaveChangesAsync(cancellationToken);
    }
}
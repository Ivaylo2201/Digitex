using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class ProductBaseRepository(DatabaseContext context) : IProductBaseRepository
{
    public async Task<ProductBase?> GetOneAsync(Guid id, CancellationToken cancellationToken)
        => await context.Products.FirstOrDefaultAsync(product => product.Id == id, cancellationToken);

    public async Task<List<ProductBase>> GetFavoritesByUserIdAsync(int userId, CancellationToken cancellationToken)
    {
        return await context.Products
            .Where(p => p.LikedBy.Any(u => u.Id == userId))
            .Include(p => p.Brand)
            .Include(p => p.LikedBy)
            .ToListAsync(cancellationToken);
    }

    public async Task AddSuggestionAsync(Guid productId, string suggestedProductSku, CancellationToken cancellationToken)
    {
        var product = await context.Products
            .Include(p => p.Suggestions)
            .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);
        
        var suggestion = await context.Products.FirstOrDefaultAsync(p => p.Sku == suggestedProductSku, cancellationToken);
        
        if (product is null || suggestion is null || product.Suggestions.Contains(suggestion))
            return;
        
        product.Suggestions.Add(suggestion);
        suggestion.Suggestions.Add(product);
        
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveSuggestionAsync(Guid productId, string suggestedProductSku, CancellationToken ct)
    {
        var product = await context.Products
            .Include(p => p.Suggestions)
            .FirstOrDefaultAsync(p => p.Id == productId, ct);

        if (product is null) return;

        var suggestion = await context.Products
            .Include(p => p.Suggestions)
            .FirstOrDefaultAsync(p => p.Sku == suggestedProductSku, ct);

        if (suggestion is null) return;

        product.Suggestions.Remove(suggestion);
        suggestion.Suggestions.Remove(product);

        await context.SaveChangesAsync(ct);
    }

    public async Task ReduceQuantityAsync(Guid productId, int quantity, CancellationToken cancellationToken)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);

        if (product is null)
            return;
        
        product.Quantity -= quantity;
        await context.SaveChangesAsync(cancellationToken);
    }
}
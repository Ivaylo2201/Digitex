using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class ProductBaseRepository(DatabaseContext context, IEmailSenderService emailSenderService) : IProductBaseRepository
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

    public async Task AddSuggestionAsync(Guid productId, Guid suggestedProductId, CancellationToken cancellationToken)
    {
        var product = await context.Products
            .Include(p => p.Suggestions)
            .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);
        
        var suggestion = await context.Products.FirstOrDefaultAsync(p => p.Id == suggestedProductId, cancellationToken);
        
        if (product is null || suggestion is null || product.Suggestions.Contains(suggestion))
            return;
        
        product.Suggestions.Add(suggestion);
        suggestion.Suggestions.Add(product);
        
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveSuggestionAsync(Guid productId, Guid suggestedProductId, CancellationToken ct)
    {
        var product = await context.Products
            .Include(p => p.Suggestions)
            .FirstOrDefaultAsync(p => p.Id == productId, ct);

        if (product is null) return;

        var suggestion = await context.Products
            .Include(p => p.Suggestions)
            .FirstOrDefaultAsync(p => p.Id == suggestedProductId, ct);

        if (suggestion is null) return;

        product.Suggestions.Remove(suggestion);
        suggestion.Suggestions.Remove(product);

        await context.SaveChangesAsync(ct);
    }

    public async Task ReduceQuantityAsync(Guid productId, int quantity, CancellationToken cancellationToken)
    {
        var product = await context.Products
            .Include(p => p.Brand)
            .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);

        if (product is null)
            return;
        
        product.Quantity -= quantity;
        await context.SaveChangesAsync(cancellationToken);

        if (product.Quantity <= 3)
        {
            await emailSenderService.SendInsufficientProductQuantityEmailAsync(product, cancellationToken);
        }
    }

    public async Task<List<ProductBase>> SearchAsync(string query, CancellationToken cancellationToken)
    {
        return await context.Products
            .Include(product => product.Brand)
            .Where(product => EF.Functions.Like(product.Brand.BrandName, $"%{query}%") || 
                              EF.Functions.Like(product.ModelName, $"%{query}%") ||
                              EF.Functions.Like(product.Sku, $"%{query}%"))
            .ToListAsync(cancellationToken);
    }

    public async Task<List<ProductBase>> GetSuggestedProductsAsync(Guid productId, CancellationToken cancellationToken)
    {
        var product = await context.Products
            .Include(p => p.Suggestions)
            .ThenInclude(p => p.Brand)
            .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);

        if (product is null) return [];

        return product.Suggestions.ToList();
    }

    public async Task<ProductBase?> GetMostSoldProductAsync(CancellationToken cancellationToken)
    {
        return await context.Products
            .Where(p => p.Sales.Any())
            .Include(p => p.Brand)
            .Include(p => p.Sales)
            .OrderByDescending(p => p.Sales.Count())
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<ProductBase>> GetSuggestionsProductsAsync(Guid productId, CancellationToken cancellationToken)
    {
        var product = await context.Products
            .Include(p => p.SuggestedBy)
            .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);

        if (product is null)
            return [];
        
        var suggestedIds = product.SuggestedBy.Select(p => p.Id).ToList();

        return await context.Products
            .Include(p => p.Brand)
            .Where(p => !suggestedIds.Contains(p.Id) && p.Id != product.Id)
            .ToListAsync(cancellationToken);
    }
}
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

public class ProductBaseService(ILogger<ProductBaseService> logger, IProductBaseRepository productBaseRepository) : IProductBaseService
{
    public async Task<Result> UpdateRatingAsync(Guid id, IServiceProvider serviceProvider, CancellationToken stoppingToken = default)
    {
        var source = GetType().Name;
        
        logger.LogInformation("[{Source}]: Getting {Service} from DI container...", source, "IReviewRepository");
        var reviewRepository = serviceProvider.GetRequiredService<IReviewRepository>();
        
        var averageRating = await reviewRepository.GetAverageRatingAsync(id);
        await productBaseRepository.UpdateRatingAsync(id, (int)Math.Round(averageRating, 0), stoppingToken);
        
        return Result.Success();
    }
}
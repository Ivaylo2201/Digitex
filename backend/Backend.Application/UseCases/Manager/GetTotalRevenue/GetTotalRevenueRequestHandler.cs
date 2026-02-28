using System.Net;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Manager.GetTotalRevenue;

public class GetTotalRevenueRequestHandler(
    ILogger<GetTotalRevenueRequestHandler> logger,
    ISaleRepository saleRepository) : IRequestHandler<GetTotalRevenueRequest, Result<GetTotalRevenueResponse>>
{
    private const string Source = nameof(GetTotalRevenueRequestHandler);
    
    public async Task<Result<GetTotalRevenueResponse>> Handle(GetTotalRevenueRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{Source}]: Getting total revenue...", Source);
        var totalRevenue = await saleRepository.GetTotalRevenueAsync(cancellationToken);
        
        return Result<GetTotalRevenueResponse>.Success(HttpStatusCode.OK, new GetTotalRevenueResponse
        {
            TotalRevenue = totalRevenue
        });
    }
}
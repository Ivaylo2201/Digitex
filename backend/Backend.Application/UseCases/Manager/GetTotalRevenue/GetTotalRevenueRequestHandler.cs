using System.Net;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;

namespace Backend.Application.UseCases.Manager.GetTotalRevenue;

public class GetTotalRevenueRequestHandler(ISaleRepository saleRepository) : IRequestHandler<GetTotalRevenueRequest, Result<GetTotalRevenueResponse>>
{
    public async Task<Result<GetTotalRevenueResponse>> Handle(GetTotalRevenueRequest request, CancellationToken cancellationToken)
    {
        var totalRevenue = await saleRepository.GetTotalRevenueAsync(cancellationToken);
        return Result<GetTotalRevenueResponse>.Success(HttpStatusCode.OK, new GetTotalRevenueResponse
        {
            TotalRevenue = totalRevenue
        });
    }
}
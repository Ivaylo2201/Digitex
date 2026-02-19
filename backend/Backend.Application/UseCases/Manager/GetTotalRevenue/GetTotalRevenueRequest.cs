using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Manager.GetTotalRevenue;

public record GetTotalRevenueRequest : IRequest<Result<GetTotalRevenueResponse>>;
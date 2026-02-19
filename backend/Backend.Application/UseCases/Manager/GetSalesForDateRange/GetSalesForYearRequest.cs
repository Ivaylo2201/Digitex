using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Manager.GetSalesForDateRange;

public record GetSalesForYearRequest : IRequest<Result<List<SalesReport>>>
{
    public required int Year { get; init; }
}
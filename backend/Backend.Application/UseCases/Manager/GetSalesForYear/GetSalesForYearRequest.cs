using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Manager.GetSalesForYear;

public record GetSalesForYearRequest : IRequest<Result<List<SalesReport>>>
{
    public required int Year { get; init; }
}
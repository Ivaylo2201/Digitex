using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Manager.GetCategorySales;

public record GetCategorySalesRequest : IRequest<Result<List<CategorySaleReport>>>;
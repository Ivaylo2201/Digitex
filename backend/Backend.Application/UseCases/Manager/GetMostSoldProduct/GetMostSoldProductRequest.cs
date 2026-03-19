using Backend.Application.DTOs.Products;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Manager.GetMostSoldProduct;

public class GetMostSoldProductRequest : IRequest<Result<MostSoldProductDto>>;
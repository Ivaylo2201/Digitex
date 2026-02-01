using Backend.Application.DTOs;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Brands.GetAllBrands;

public record GetAllBrandsRequest : IRequest<Result<IEnumerable<BrandDto>>>;
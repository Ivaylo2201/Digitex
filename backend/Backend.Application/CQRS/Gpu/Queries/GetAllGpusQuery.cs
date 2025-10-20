using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.CQRS.Gpu.Queries;

using Gpu = Domain.Entities.Gpu;

public record GetAllGpusQuery : IRequest<Result<IEnumerable<Gpu>>>;
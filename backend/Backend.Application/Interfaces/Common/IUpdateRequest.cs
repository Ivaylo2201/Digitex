using Microsoft.AspNetCore.Http;

namespace Backend.Application.Interfaces.Common;

public interface IUpdateRequest
{
    Guid Id { get; }
    IFormFile Image { get; }
}
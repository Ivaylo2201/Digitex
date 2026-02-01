using Microsoft.AspNetCore.Http;

namespace Backend.Application.Interfaces.Common;

public interface ICreateRequest
{
    IFormFile Image { get; }
}
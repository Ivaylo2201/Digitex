using Backend.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Interfaces.Services;

public interface IFileService<TProduct> where TProduct : ProductBase
{
    Task<string> SaveFileAsync(IFormFile file);
}
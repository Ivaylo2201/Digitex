using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Infrastructure.Services;

public class FileService<TProduct>(IWebHostEnvironment env) : IFileService<TProduct> where TProduct : ProductBase
{
    public async Task<string> SaveFileAsync(IFormFile file)
    {
        var subfolder = typeof(TProduct) switch
        {
            var product when product == typeof(GraphicsCard) => "graphics-cards",
            var product when product == typeof(Monitor)      => "monitors",
            var product when product == typeof(Motherboard)  => "motherboards",
            var product when product == typeof(PowerSupply)  => "power-supplies",
            var product when product == typeof(Processor)    => "processors",
            var product when product == typeof(Ram)          => "rams",
            var product when product == typeof(Ssd)          => "ssds",
            _ => throw new NotSupportedException("Invalid subfolder mapping.")
        };
        
        var folderPath = Path.Combine(env.WebRootPath, subfolder);
        Directory.CreateDirectory(folderPath);

        var filePath = Path.Combine(folderPath, file.FileName);

        await using var fs = File.Create(filePath);
        await file.CopyToAsync(fs);

        return $"{subfolder}/{file.FileName}";
    }
}

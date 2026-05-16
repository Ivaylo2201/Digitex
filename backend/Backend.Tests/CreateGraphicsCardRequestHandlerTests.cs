using System.Net;
using Backend.Application.UseCases.Products.CreateProduct;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Moq;

namespace Backend.Tests;

public class CreateGraphicsCardRequestHandlerTests
{
    private readonly Mock<IProductRepository<GraphicsCard>> _productRepository = new();
    private readonly Mock<IFileService<GraphicsCard>> _fileService = new();

    private readonly CreateGraphicsCardRequestHandler _handler;

    public CreateGraphicsCardRequestHandlerTests()
    {
        _handler = new CreateGraphicsCardRequestHandler(
            _productRepository.Object,
            _fileService.Object);
    }

    [Fact]
    public async Task Handle_Should_Create_GraphicsCard_Successfully()
    {
        // Arrange
        var request = new CreateGraphicsCardRequest
        {
            BrandId = 1,
            ModelName = "RTX 4090",
            DiscountPercentage = 10,
            InitialPrice = 2000,
            Quantity = 5,
            Memory = new Memory(16,
                MemoryType.Ddr4,
                3200),
            ClockSpeed = new ClockSpeed(2200,
                2000),
            BusWidth = 384,
            CudaCores = 16384,
            DirectXSupport = 12,
            Tdp = 450,
            Image = null
        };

        var imagePath = "images/rtx4090.png";

        _fileService
            .Setup(x => x.SaveFileAsync(It.IsAny<IFormFile>()))
            .ReturnsAsync(imagePath);

        GraphicsCard? capturedProduct = null;

        _productRepository
            .Setup(x => x.CreateAsync(It.IsAny<GraphicsCard>(), It.IsAny<CancellationToken>()))
            .Callback<GraphicsCard, CancellationToken>((p, _) => capturedProduct = p)
            .ReturnsAsync((GraphicsCard p, CancellationToken _) => p);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal((int)HttpStatusCode.Created, result.StatusCode);

        Assert.NotNull(capturedProduct);
        Assert.Equal(request.ModelName, capturedProduct.ModelName);
        Assert.Equal(request.BusWidth, capturedProduct.BusWidth);
        Assert.Equal(imagePath, capturedProduct.ImagePath);
    }

    [Fact]
    public async Task Handle_Should_Call_Repository_Once()
    {
        // Arrange
        var request = new CreateGraphicsCardRequest
        {
            BrandId = 1,
            ModelName = "RTX 4080",
            DiscountPercentage = 5,
            InitialPrice = 1500,
            Quantity = 3,
            Memory = new Memory(16,
                MemoryType.Ddr4,
                3200),
            ClockSpeed = new ClockSpeed(2200,
                2000),
            BusWidth = 256,
            CudaCores = 9728,
            DirectXSupport = 12,
            Tdp = 320,
            Image = null
        };

        _fileService
            .Setup(x => x.SaveFileAsync(It.IsAny<IFormFile>()))
            .ReturnsAsync("image.png");

        _productRepository
            .Setup(x => x.CreateAsync(It.IsAny<GraphicsCard>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((GraphicsCard p, CancellationToken _) => p);

        // Act
        await _handler.Handle(request, CancellationToken.None);

        // Assert
        _productRepository.Verify(
            x => x.CreateAsync(It.IsAny<GraphicsCard>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }
}

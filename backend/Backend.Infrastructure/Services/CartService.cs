using Backend.Application.Dtos.Cart;
using Backend.Application.Interfaces.Services;
using Backend.Application.Validators;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Backend.Infrastructure.Services;

public class CartService(ILogger<CartService> logger, ICartRepository cartRepository, IUserRepository userRepository) : ICartService
{
    private const string Source = nameof(CartService);
    
    public async Task<Result> AddToCartAsync(AddToCartDto addToCartDto, CancellationToken stoppingToken)
    {
        logger.LogInformation("[{Source}]: Validating AddToCart request body...", Source);
        var validationResult = await new AddToCartValidator().ValidateAsync(addToCartDto, stoppingToken);

        if (!validationResult.IsValid)
        {
            var serializedDto = JsonConvert.SerializeObject(addToCartDto);
            var errors = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
            
            logger.LogError("[{Source}]: Sign up validation failed for {SerializedDto}. Errors: {Errors}", Source, serializedDto, errors);
            return Result<string>.Failure(StatusCodes.Status400BadRequest, ErrorType.ValidationFailed, details: validationResult.Errors.ToObject());
        }

        try
        {
            Console.WriteLine(addToCartDto.UserId);
            var user = await userRepository.GetOneByIdWithCartAsync(addToCartDto.UserId, stoppingToken);

            if (user is null)
            {
                logger.LogWarning("[{Source}]: No verified user was found by Id.", Source);
                return Result.Failure(StatusCodes.Status404NotFound);
            }

            var item = new Item
            {
                ProductId = addToCartDto.ProductId,
                Quantity = addToCartDto.Quantity,
                CartId = user.Cart.Id
            };
        
            await cartRepository.AddToCartAsync(item, stoppingToken);
            return Result.Success(StatusCodes.Status201Created);
        }
        catch (Exception ex)
        {
            logger.LogException(Source, ex, "adding to cart");
            return Result.Failure(StatusCodes.Status400BadRequest, ErrorType.DatabaseError);   
        }
    }
}
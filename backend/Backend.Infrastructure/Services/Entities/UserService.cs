using Backend.Application.DTOs.User;
using Backend.Application.Interfaces.Services;
using Backend.Application.Validators;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

public class UserService(ILogger<UserService> logger, IUserRepository userRepository, ITokenService tokenService) : IUserService
{
    public async Task<Result<string>> SignInAsync(SignInDto signInDto, CancellationToken stoppingToken = default)
    {
        var validationResult = await new SignInValidator().ValidateAsync(signInDto, stoppingToken);

        if (!validationResult.IsValid)
            return Result<string>.Failure(ErrorType.InvalidCredentials, validationResult.Errors.ToObject());
        
        var user = await userRepository.GetOneByCredentialsAsync(signInDto.Username, signInDto.Password, stoppingToken);

        if (user is null)
            return Result<string>.Failure(ErrorType.InvalidCredentials);
        
        return Result<string>.Success(tokenService.GenerateToken(user));
    }

    public async Task<Result<string>> SignUpAsync(SignUpDto signUpDto, CancellationToken stoppingToken = default)
    {
        var validationResult = await new SignUpValidator().ValidateAsync(signUpDto, stoppingToken);

        if (!validationResult.IsValid)
            return Result<string>.Failure(ErrorType.InvalidCredentials, validationResult.Errors.ToObject());
        
        var isUsernameAvailable = await userRepository.IsUsernameAvailableAsync(signUpDto.Username, stoppingToken);

        if (!isUsernameAvailable)
            return Result<string>.Failure(ErrorType.UsernameTaken);
        
        var user = await userRepository.CreateAsync(new User
        {
            Username = signUpDto.Username,
            Password = signUpDto.Password,
            Cart = new Cart()
        }, stoppingToken);
        
        return Result<string>.Success(tokenService.GenerateToken(user));
    }
}
using Backend.Application.DTOs.User;
using Backend.Application.Interfaces.Services;
using Backend.Application.Validators;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Services.Entities;

public class UserService(
    IUserRepository userRepository,
    ITokenService tokenService,
    IEmailCryptoService emailCryptoService,
    IEmailSendingService emailSendingService) : IUserService
{
    public async Task<Result<string>> SignInAsync(SignInDto signInDto, CancellationToken stoppingToken = default)
    {
        var validationResult = await new SignInValidator().ValidateAsync(signInDto, stoppingToken);

        if (!validationResult.IsValid)
            return Result<string>.Failure(ErrorType.ValidationFailed, validationResult.Errors.ToObject());
        
        var user = await userRepository.GetOneByCredentialsAsync(signInDto.Email, signInDto.Password, stoppingToken);

        if (user is null)
            return Result<string>.Failure(ErrorType.InvalidCredentials);
        
        return Result<string>.Success(tokenService.GenerateToken(user));
    }

    public async Task<Result> SignUpAsync(SignUpDto signUpDto, CancellationToken stoppingToken = default)
    {
        var validationResult = await new SignUpValidator().ValidateAsync(signUpDto, stoppingToken);

        if (!validationResult.IsValid)
            return Result<string>.Failure(ErrorType.InvalidCredentials, validationResult.Errors.ToObject());

        try
        {
            var user = await userRepository.CreateAsync(new User
            {
                Username = signUpDto.Username,
                Password = signUpDto.Password,
                Email = signUpDto.Email,
                Cart = new Cart()
            }, stoppingToken);
            
            await emailSendingService.SendVerificationMailAsync(user, stoppingToken);

            return Result.Success();
        }
        catch (DbUpdateException)
        {
            return Result.Failure(ErrorType.EmailTaken);       
        }
        catch (Exception)
        {
            return Result.Failure(ErrorType.Other);
        }
    }

    public async Task<Result> VerifyUserAsync(string token, CancellationToken stoppingToken = default)
    {
        var email = emailCryptoService.Decrypt(token);
        var isVerificationSuccessful = await userRepository.VerifyUserAsync(email, stoppingToken);
        return isVerificationSuccessful ? Result.Success() : Result.Failure(ErrorType.InvalidCredentials);       
    }
}
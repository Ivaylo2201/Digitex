using System.Diagnostics;
using Backend.Application.CQRS.Entities.User.Commands;
using Backend.Application.Extensions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Entities.User.Handlers;

public class SignInUserCommandHandler(
    ILogger<SignInUserCommandHandler> logger,
    IUserRepository userRepository,
    ITokenService tokenService) : ICommandHandler<SignInUserCommand, Result<string>>
{
    private const string QueryName = nameof(SignInUserCommand);
    private const string Source = nameof(SignInUserCommandHandler);
    
    public async Task<Result<string>> HandleAsync(SignInUserCommand command, CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        logger.LogQueryExecutionStart(Source, QueryName);
        
        var user = await userRepository.GetOneByCredentialsAsync(command.Dto.Username, command.Dto.Password, cancellationToken);

        if (user is null)
        {
            logger.LogQueryExecutionDuration(Source, QueryName, stopwatch);
            return Result<string>.Failure(ErrorType.InvalidCredentials);
        }
        
        logger.LogQueryExecutionDuration(Source, QueryName, stopwatch);
        return Result<string>.Success(tokenService.GenerateToken(user));
    }
}
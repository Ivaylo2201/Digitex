using System.Diagnostics;
using Backend.Application.CQRS.User.Commands;
using Backend.Application.Extensions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.User.Handlers;

using User = Domain.Entities.User;

public class SignUpUserCommandHandler(ILogger<SignUpUserCommandHandler> logger, ITokenService tokenService, IUserRepository userRepository) : ICommandHandler<SignUpUserCommand, Result<string>>
{
    private const string QueryName = nameof(SignUpUserCommand);
    private const string Source = nameof(SignUpUserCommandHandler);

    public async Task<Result<string>> HandleAsync(SignUpUserCommand command, CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        logger.LogQueryExecutionStart(Source, QueryName);
        
        var isUsernameAvailable = await userRepository.IsUsernameAvailableAsync(command.Dto.Username, cancellationToken);

        if (!isUsernameAvailable)
        {
            logger.LogQueryExecutionDuration(Source, QueryName, stopwatch);
            return Result<string>.Failure(ErrorType.UsernameTaken);
        }
        
        var user = new User
        {
            Username = command.Dto.Username,
            Password = command.Dto.Password
        };

        await userRepository.CreateAsync(user, cancellationToken);
        logger.LogQueryExecutionDuration(Source, QueryName, stopwatch);
        
        return Result<string>.Success(tokenService.GenerateToken(user));
    }
}
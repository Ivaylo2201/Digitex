using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.Validation;

public class ValidationPipeline(ILogger<ValidationPipeline> logger, IServiceProvider provider, ValidationPipelineOptions options) : IPipeline
{
    private const string Source = nameof(ValidationPipeline);
    
    private async Task ValidateInstanceAsync<T>(T instance, CancellationToken ct) where  T : class
    {
        var validator = provider.GetService<IValidator<T>>();
        
        if (validator is null)
        {
            logger.LogError("[{Source}]: IValidator<{Type}> not found.", Source, typeof(T).Name);
            return;
        }
        
        logger.LogInformation("[{Source}]: Validating instance of type {Type}", Source, typeof(T).Name);
        var result = await validator.ValidateAsync(instance, ct).ConfigureAwait(false);

        if (result.IsValid)
        {
            logger.LogInformation("[{Source}]: Validation passed.", Source);
            return;
        }

        if (options.OnFailedValidation != null)
            await options.OnFailedValidation(instance, result, ct).ConfigureAwait(false);

        throw new ValidationException(result.Errors);
    }
    
    public async Task OnCommandAsync<TCommand>(Func<TCommand, CancellationToken, Task> next, TCommand cmd, CancellationToken ct) where TCommand : class, ICommand
    {
        if (options.ValidateCommand)
            await ValidateInstanceAsync(cmd, ct).ConfigureAwait(false);
        
        await next(cmd, ct).ConfigureAwait(false);
    }

    public async Task<TResult> OnCommandAsync<TCommand, TResult>(Func<TCommand, CancellationToken, Task<TResult>> next, TCommand cmd, CancellationToken ct) where TCommand : class, ICommand<TResult>
    {
        if (options.ValidateCommand)
            await ValidateInstanceAsync(cmd, ct).ConfigureAwait(false);
        
        return await next(cmd, ct).ConfigureAwait(false);
    }
    
    public Task OnEventAsync<TEvent>(Func<TEvent, CancellationToken, Task> next, TEvent evt, CancellationToken ct) where TEvent : class, IEvent 
        => next(evt, ct);
    
    public Task<TResult> OnQueryAsync<TQuery, TResult>(Func<TQuery, CancellationToken, Task<TResult>> next, TQuery query, CancellationToken ct) where TQuery : class, IQuery<TResult> 
        => next(query, ct);
}
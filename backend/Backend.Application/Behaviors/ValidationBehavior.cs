using FluentValidation;
using MediatR;

namespace Backend.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) 
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        
        var validationFailures = validators
            .Select(validator => validator.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(validationFailure => validationFailure is not null)
            .ToList();

        if (validationFailures.Count is not 0)
            throw new ValidationException("Validation failed.");
        
        return await next();
    }
}

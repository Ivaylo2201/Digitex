using System.Reflection;
using Backend.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) => services
        .AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
        .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
        .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
}
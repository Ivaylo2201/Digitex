using System.Reflection;
using Backend.Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Backend.Application;

public static class ApplicationDependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        try
        {
            services
                .AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            
            Log.Information("[{ClassName}]: Application services successfully initialized.", nameof(ApplicationDependencyInjection));
        }
        catch (Exception ex)
        {
            Log.Error("[{ClassName}]: {ExceptionType} occurred while configuring DI for Application. Exception message: {ExceptionMessage}", nameof(ApplicationDependencyInjection), ex.GetType().Name, ex.Message);
        }
    }
}
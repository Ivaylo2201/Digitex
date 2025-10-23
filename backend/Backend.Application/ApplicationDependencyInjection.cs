using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Backend.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        try
        {
            services.AddMediator(options =>
            {
                var assembly = Assembly.GetExecutingAssembly();

                options
                    .AddHandlersFromAssembly(assembly)
                    .AddValidatorsFromAssembly(assembly)
                    .AddPipelineForValidation();
            });
            
            Log.Information("[{ClassName}]: Application services successfully initialized.", nameof(ApplicationDependencyInjection));
        }
        catch (Exception ex)
        {
            Log.Error("[{ClassName}]: {ExceptionType} occurred while configuring DI for Application. Exception message: {ExceptionMessage}", nameof(ApplicationDependencyInjection), ex.GetType().Name, ex.Message);
        }
        
        return services;       
    }
}
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Backend.Application;

public static class ApplicationDependencyInjection
{
    private const string Source = nameof(ApplicationDependencyInjection);
    
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        try
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            services
                .AddMediator(options =>
                {
                    options
                        .AddHandlersFromAssembly(assembly)
                        .AddValidatorsFromAssembly(assembly)
                        .AddPipelineForValidation(pipeline => pipeline.ValidateCommand = true);
                });
            
            Log.Information("[{Source}]: Application services successfully initialized.", Source);
        }
        catch (Exception ex)
        {
            Log.Error("[{Source}]: {ExceptionType} occurred while configuring DI for Application. Exception message: {ExceptionMessage}", Source, ex.GetType().Name, ex.Message);
        }
        
        return services;       
    }
}
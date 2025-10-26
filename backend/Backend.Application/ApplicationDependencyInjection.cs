using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SimpleSoft.Mediator;
using ValidationPipeline = Backend.Application.Validation.ValidationPipeline;

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
                .AddSingleton(_ => new ValidationPipelineOptions { ValidateCommand = true })
                .AddMediator(options =>
                {
                    options
                        .AddHandlersFromAssembly(assembly)
                        .AddValidatorsFromAssembly(assembly)
                        .AddPipeline<ValidationPipeline>();
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
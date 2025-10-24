using System.Reflection;
using Backend.Application.DTOs;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Backend.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        try
        {
            services
                .AddMapsterTypeConfigs()
                .AddMediator(options =>
                {
                    var assembly = Assembly.GetExecutingAssembly();

                    TypeAdapterConfig<Cpu, CpuDto>.NewConfig()
                        .Map(dest => dest.Brand, src => src.Brand.BrandName);

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

    private static IServiceCollection AddMapsterTypeConfigs(this IServiceCollection services)
    {
        TypeAdapterConfig<Cpu, CpuDto>.NewConfig()
            .Map(dest => dest.Brand, src => src.Brand.BrandName);
        
        return services;       
    }
}
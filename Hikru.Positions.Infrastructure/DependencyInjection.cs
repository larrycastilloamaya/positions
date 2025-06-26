using Hikru.Positions.Application.Interfaces;
using Hikru.Positions.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddHttpClient<IApexPositionService, ApexPositionService>();
        services.AddHttpClient<IApexDepartmentService, ApexDepartmentService>();
             services.AddHttpClient<IApexRecruiterService, ApexRecruiterService>();
        return services;
    }
}

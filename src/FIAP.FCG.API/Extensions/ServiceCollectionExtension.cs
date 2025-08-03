using FIAP.FCG.Infrastructure.CorrelationId;

namespace FIAP.FCG.API.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCorrelationIdGenerator(this IServiceCollection services)
    {
        services.AddTransient<ICorrelationIdGenerator, CorrelationIdGenerator>();

        return services;
    }
}

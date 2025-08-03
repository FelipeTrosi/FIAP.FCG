using FIAP.FCG.Infrastructure.Middlewares;

namespace FIAP.FCG.API.Extensions;

public static class CorrelationMiddlewareExtension
{
    public static IApplicationBuilder UseCorrelationMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CorrelationMiddleware>();
    }
}

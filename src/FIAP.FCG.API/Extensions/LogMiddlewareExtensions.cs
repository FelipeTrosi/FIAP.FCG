using FIAP.FCG.API.Middleware;

namespace FIAP.FCG.API.Extensions;

public static class LogMiddlewareExtensions
{
    public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        => builder.UseMiddleware<LogMiddleware>();

}
using FIAP.FCG.API.Services;
using FIAP.FCG.Infrastructure.Logger;
using FIAP.FCG.Service.Interfaces;
using FIAP.FCG.Service.Services;

namespace FIAP.FCG.API.Extensions; 

public static class ServiceDIExtension
{
    public static IServiceCollection AddServiceDI(this IServiceCollection services)
    {
        services.AddTransient(typeof(IBaseLogger<>), typeof(BaseLogger<>));
        services.AddTransient<IAuthService, AuthService>();

        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IGameService, GameService>();

        return services;
    }
}

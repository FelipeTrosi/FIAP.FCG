using FIAP.FCG.Domain.Repository.Interfaces;
using FIAP.FCG.Infrastructure.Repository;

namespace FIAP.FCG.API.Extensions
{
    public static class RepositoryDIExtension
    {
        public static IServiceCollection AddRepositoryDI(this IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}

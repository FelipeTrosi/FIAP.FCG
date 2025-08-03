using FIAP.FCG.Domain.Entity;
using FIAP.FCG.Infrastructure.Repository.Interfaces;

namespace FIAP.FCG.Infrastructure.Repository
{
    public class GameRepository : EFRepository<GameEntity>, IGameRepository
    {
        public GameRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

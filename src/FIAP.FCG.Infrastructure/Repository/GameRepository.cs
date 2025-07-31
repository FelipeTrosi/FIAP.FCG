using FIAP.FCG.Domain.Repository.Interfaces;
using FIAP.FCG.Domain.Entity;

namespace FIAP.FCG.Infrastructure.Repository
{
    public class GameRepository : EFRepository<GameEntity>, IGameRepository
    {
        public GameRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

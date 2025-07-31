using FIAP.FCG.Domain.Entity;
using FIAP.FCG.Domain.Entity.Game.Input;

namespace FIAP.FCG.Domain.Services.Interfaces
{
    public interface IGameService
    {
        ICollection<GameEntity> GetAll();
        GameEntity? GetById(long id);
        void Create(CreateGameInput entity);
        void Update(UpdateGameInput entity);
        void DeleteById(long id);
    }
}

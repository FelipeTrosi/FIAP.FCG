using FIAP.FCG.Domain.Entity;
using FIAP.FCG.Domain.Entity.Game.Input;
using FIAP.FCG.Domain.Repository.Interfaces;
using FIAP.FCG.Domain.Services.Interfaces;

namespace FIAP.FCG.Service.Services
{
    public class GameService(IGameRepository repository) : IGameService
    {
        private readonly IGameRepository _repository = repository;

        public void Create(CreateGameInput entity)
            => _repository.Create(new()
            {
                CreatedAt = DateTime.Now,
                Name = entity.Name,
                Code = entity.Code,
                Description = entity.Description
            });

        public void DeleteById(long id)
            => _repository.DeleteById(id);

        public ICollection<GameEntity> GetAll()
            => _repository.GetAll();

        public GameEntity? GetById(long id)
            => _repository.GetById(id);

        public void Update(UpdateGameInput entity)
            => _repository.Update(new()
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
                Name = entity.Name,
                Code = entity.Code,
                Description = entity.Description
            });
    }
}

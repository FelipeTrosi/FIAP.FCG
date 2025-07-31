using FIAP.FCG.Domain.Entity;
using FIAP.FCG.Domain.Entity.User.Input;
using FIAP.FCG.Domain.Repository.Interfaces;
using FIAP.FCG.Domain.Services.Interfaces;

namespace FIAP.FCG.Service.Services
{
    public class UserService(IUserRepository repository) : IUserService
    {
        private readonly IUserRepository _repository = repository;

        public void Create(CreateUserInput entity)
            => _repository.Create(new()
            {
                AccessLevel = entity.AccessLevel,
                CreatedAt = DateTime.Now,
                Email = entity.Email,
                Name = entity.Name,
                Password = entity.Password
            });

        public void DeleteById(long id)
            => _repository.DeleteById(id);

        public ICollection<UserEntity> GetAll()
            => _repository.GetAll();

        public UserEntity? GetById(long id)
            => _repository.GetById(id);

        public void Update(UpdateUserInput entity)
            => _repository.Update(new()
            {
                Id = entity.Id,
                AccessLevel = entity.AccessLevel,
                CreatedAt = entity.CreatedAt,
                Email = entity.Email,
                Name = entity.Name,
                Password = entity.Password
            });
    }
}

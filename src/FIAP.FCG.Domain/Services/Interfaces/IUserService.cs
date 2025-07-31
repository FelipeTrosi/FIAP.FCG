using FIAP.FCG.Domain.Entity;
using FIAP.FCG.Domain.Entity.User.Input;

namespace FIAP.FCG.Domain.Services.Interfaces
{
    public interface IUserService
    {
        ICollection<UserEntity> GetAll();
        UserEntity? GetById(long id);
        void Create(CreateUserInput entity);
        void Update(UpdateUserInput entity);
        void DeleteById(long id);
    }
}

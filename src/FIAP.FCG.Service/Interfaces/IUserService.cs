using FIAP.FCG.Service.Dto.User;

namespace FIAP.FCG.Service.Interfaces;
public interface IUserService
{
    ICollection<UserOutputDto> GetAll();
    UserOutputDto? GetById(long id);
    void Create(UserCreateDto entity);
    void Update(UserUpdateDto entity);
    void DeleteById(long id);
    UserOutputDto GetByUserAndPassword(string user, string password);

}

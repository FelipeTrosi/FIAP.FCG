using FIAP.FCG.Service.Dto.Login;

namespace FIAP.FCG.Service.Interfaces;

public interface IAuthService
{
    string Login(LoginDto input);
}

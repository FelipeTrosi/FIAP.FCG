using FIAP.FCG.Infrastructure.Logger;
using FIAP.FCG.Infrastructure.Repository.Interfaces;
using FIAP.FCG.Service.Dto.User;
using FIAP.FCG.Service.Exceptions;
using FIAP.FCG.Service.Interfaces;
using FIAP.FCG.Service.Util;

namespace FIAP.FCG.Service.Services;

public class UserService(IBaseLogger<UserService> logger, IUserRepository repository) : IUserService
{
    private readonly IUserRepository _repository = repository;
    private readonly IBaseLogger<UserService> _logger = logger;

    public void Create(UserCreateDto entity)
    {
        var errors = new Dictionary<string, string[]>();

        _logger.LogInformation("Iniciando serviço 'CREATE' de usuário !");

        if (!ValidatorService.IsValidEmail(entity.Email))
        {
            _logger.LogError("Email inválido");
            errors["Email"] = ["Email inválido"];
        }

        if (!ValidatorService.IsValidPassword(entity.Password))
        {
            _logger.LogError("Senha deve conter letras, números e caracteres especiais, com pelo menos 8 caracteres.");
            errors["Senha"] = ["Senha deve conter letras, números e caracteres especiais, com pelo menos 8 caracteres."];
        }

        if (errors.Any())
            throw new BadRequestException("Erro de validação", errors);


        _repository.Create(new()
        {
            AccessLevel = entity.AccessLevel,
            CreatedAt = DateTime.Now,
            Email = entity.Email,
            Name = entity.Name,
            Password = entity.Password
        });

        _logger.LogInformation("Usuário cadastrado com sucesso !");
    }

    public void DeleteById(long id)
    {
        _logger.LogInformation($"Iniciando serviço 'DELETE' por Id: {id} de usuário !");

        var entity = _repository.GetById(id);

        if (entity == null)
        {
            _logger.LogWarning($"Registro não encontrado para o id: {id}");
            throw new NotFoundException($"Registro não encontrado para o id: {id}");
        }

        _repository.DeleteById(id);

        _logger.LogInformation($"Usuário com id {id} removido com sucesso !");
    }

    public ICollection<UserOutputDto> GetAll()
    {
        _logger.LogInformation("Iniciando serviço 'GETALL' de usuário !");

        return ParseModel.Map<ICollection<UserOutputDto>>(_repository.GetAll());
    }

    public UserOutputDto? GetById(long id)
    {
        _logger.LogInformation($"Iniciando serviço 'GET' por Id: {id} de usuário !");

        var result = _repository.GetById(id);

        if (result != null)
            return ParseModel.Map<UserOutputDto>(result);
        else
        {
            _logger.LogWarning($"Usuário com Id: {id} não encontrado !");
            throw new NotFoundException($"Registro não encontrado para o id: {id}"); ;
        }
    }

    public void Update(UserUpdateDto entity)
    {
        var errors = new Dictionary<string, string[]>();
        
        _logger.LogInformation($"Iniciando serviço 'UPDATE' de usuário com Id {entity.Id}!");

        if (!ValidatorService.IsValidEmail(entity.Email))
        {
            _logger.LogError("Email inválido");
            errors["Email"] = ["Email inválido"];
        }

        if (!ValidatorService.IsValidPassword(entity.Password))
        {
            _logger.LogError("Senha deve conter letras, números e caracteres especiais, com pelo menos 8 caracteres.");
            errors["Senha"] = ["Senha deve conter letras, números e caracteres especiais, com pelo menos 8 caracteres."];
        }

        if (errors.Any())
            throw new BadRequestException("Erro de validação", errors);

        _repository.Update(new()
        {
            Id = entity.Id,
            AccessLevel = entity.AccessLevel,
            CreatedAt = entity.CreatedAt,
            Email = entity.Email,
            Name = entity.Name,
            Password = entity.Password
        });

        _logger.LogInformation($"Usuário com Id {entity.Id} atualizado com sucesso !");
    }

    public UserOutputDto GetByUserAndPassword(string user, string password)
    {
        var result = _repository.GetByUserAndPassword(user, password) ?? throw new UnauthorizedException("Login inválido !");
        return ParseModel.Map<UserOutputDto>(result);
    }
    

}

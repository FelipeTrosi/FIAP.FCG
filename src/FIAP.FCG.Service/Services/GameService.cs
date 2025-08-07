using FIAP.FCG.Infrastructure.Logger;
using FIAP.FCG.Infrastructure.Repository.Interfaces;
using FIAP.FCG.Service.Dto.Game;
using FIAP.FCG.Service.Exceptions;
using FIAP.FCG.Service.Interfaces;
using FIAP.FCG.Service.Util;

namespace FIAP.FCG.Service.Services;

public class GameService(IBaseLogger<GameService> logger, IGameRepository repository) : IGameService
{
    private readonly IGameRepository _repository = repository;
    private readonly IBaseLogger<GameService> _logger = logger;


    public void Create(GameCreateDto entity)
    {
        _logger.LogInformation("Iniciando serviço 'CREATE' de jogo !");

        _repository.Create(new()
        {
            CreatedAt = DateTime.Now,
            Name = entity.Name,
            Code = entity.Code,
            Description = entity.Description
        });

        _logger.LogInformation("Jogo cadastrado com sucesso !");
    }


    public void DeleteById(long id)
    {
        _logger.LogInformation($"Iniciando serviço 'DELETE' por Id: {id} de jogo !");

        var entity = _repository.GetById(id);

        if(entity == null)
        {
            _logger.LogWarning($"Registro não encontrado para o id: {id}");
            throw new NotFoundException($"Registro não encontrado para o id: {id}");
        }

        _repository.DeleteById(entity.Id);

        _logger.LogInformation($"Jogo com id {id} removido com sucesso !");
    }

    public ICollection<GameOutputDto> GetAll()
    {
        _logger.LogInformation("Iniciando serviço 'GETALL' de jogo !");

        return ParseModel.Map<ICollection<GameOutputDto>>(_repository.GetAll());
    }

    public GameOutputDto? GetById(long id)
    {
        _logger.LogInformation($"Iniciando serviço 'GET' por Id: {id} de jogo !");

        var result = _repository.GetById(id);

        if (result != null)
            return ParseModel.Map<GameOutputDto>(result);
        else
        {
            _logger.LogWarning($"Jogo com Id: {id} não encontrado !");
            throw new NotFoundException($"Registro não encontrado para o id: {id}");
        }
    }

    public void Update(GameUpdateDto entity)
    {
        _logger.LogInformation($"Iniciando serviço 'UPDATE' de jogo com Id {entity.Id}!");

        _repository.Update(new()
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            Name = entity.Name,
            Code = entity.Code,
            Description = entity.Description
        });

        _logger.LogInformation($"Jogo com Id {entity.Id} atualizado com sucesso !");
    }
}

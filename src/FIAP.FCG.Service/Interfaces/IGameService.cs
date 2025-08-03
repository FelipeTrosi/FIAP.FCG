using FIAP.FCG.Service.Dto.Game;

namespace FIAP.FCG.Service.Interfaces;
public interface IGameService
{
    ICollection<GameOutputDto> GetAll();
    GameOutputDto? GetById(long id);
    void Create(GameCreateDto entity);
    void Update(GameUpdateDto entity);
    void DeleteById(long id);
}

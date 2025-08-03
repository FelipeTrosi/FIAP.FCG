namespace FIAP.FCG.Service.Dto.Game;

public  class GameCreateDto
{
    public long Code { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}

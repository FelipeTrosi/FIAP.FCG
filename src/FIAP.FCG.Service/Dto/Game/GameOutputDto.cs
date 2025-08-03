namespace FIAP.FCG.Service.Dto.Game
{
    public class GameOutputDto
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public long Code { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}

namespace FIAP.FCG.Domain.Entity
{
    public class GameEntity : EntityBase
    {
        public long Code { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}

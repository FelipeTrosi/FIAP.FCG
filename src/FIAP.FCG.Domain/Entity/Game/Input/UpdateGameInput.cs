namespace FIAP.FCG.Domain.Entity.Game.Input
{
    public  class UpdateGameInput : EntityBase
    {
        public long Code { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}


namespace Domain.Entities
{
    public class Position
    {
        public int PositionId { get; set; }
        public string Description { get; set; }
        public int Hierarchy { get; set; }
        public int MaxMonthlyAmount { get; set; }
    }
}
using Application.DTO.Response;
using Domain.Entities;

namespace Application.DTO.Creator
{
    public class PositionCreator
    {
        public PositionResponse Create(Position position)
        {
            return new PositionResponse()
            {
                 PositionId = position.PositionId,
                 Description = position.Description,
                 Hierarchy = position.Hierarchy,
                 MaxMonthlyAmount = position.MaxMonthlyAmount,
            };
        }
    }
}

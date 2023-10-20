using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IPositionQuery
    {
       // public IList<Position> GetPositions();
       // public Position? GetPosition(int positionId);
        Task<IList<Position>> GetPositions();
        Task<Position>? GetPosition(int positionId);
    }
}


using Application.DTO.Request;
using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IServices
{
    public interface IPositionService
    {
        //   public IList<PositionResponse> GetPosition();
        //   public PositionResponse? GetPosition(int positionId);

        Task<IList<PositionResponse>> GetPositions();
        Task<PositionResponse>? GetPosition(int positionId);
        Task<Position> CreatePosition(PositionRequest request);
    }
}

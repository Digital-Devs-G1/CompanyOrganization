using Application.DTO.Request;
using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IServices
{
    public interface IPositionService
    {
        Task<List<PositionResponse>> GetPositions();
        Task<PositionResponse> GetPosition(int positionId);
        Task<Position> CreatePosition(PositionRequest request);
    }
}

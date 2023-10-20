﻿using Application.DTO.Creator;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
{
    public class PositionService : IPositionService
    {
        private IPositionQuery _repository;
        private PositionCreator _creator;
        private IPositionCommand _command;
        public PositionService(IPositionQuery repository, IPositionCommand command)
        {
            _repository = repository;
            _creator = new PositionCreator();
            _command = command;
        }

        public async Task<IList<PositionResponse>> GetPositions()
        {
            IList<PositionResponse> list = new List<PositionResponse>();
            IList<Position> entities = await _repository.GetPositions();
            foreach (Position entity in entities)
            {
                list.Add(_creator.Create(entity));
            }
            return list;
        }
        public async Task<PositionResponse>? GetPosition(int positionId)
        {
            Position? entity = await _repository.GetPosition(positionId);
            if (entity != null)
                return _creator.Create(entity);
            return null;
        }
        public async Task<Position> CreatePosition(PositionRequest request)
        {
            //var position = new Position
            //{
            //    Description = request.Description,
            //    Hierarchy = request.Hierarchy,
            //    MaxMonthlyAmount = request.MaxMonthlyAmount

            //};
            await _command.InsertPosition(new Position());
            return new Position();
        }
    }
}
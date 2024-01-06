using Application.DTO.Request;
using Application.DTO.Response;
using Application.Exceptions;
using Application.Interfaces.IRepositories;
using Application.UseCases;
using Azure;
using Azure.Core;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using System.Collections;

namespace UnitTest
{
    public class PositionTest
    {
        [Fact]
        public async Task TestCreatePositionHappyWay()
        {
            //ARRANGE
            var mockQuery = new Mock<IPositionQuery>();
            var mockCommand = new Mock<IPositionCommand>();
            var validatorMock = new Mock<IValidator<PositionRequest>>();
            validatorMock.Setup(v => v.ValidateAsync(It.IsAny<PositionRequest>(), default))
                .ReturnsAsync(new ValidationResult());
            mockCommand.Setup(command => command.InsertPosition(It.IsAny<Position>())).ReturnsAsync(1);
            var service = new PositionService(mockQuery.Object, mockCommand.Object, validatorMock.Object);
            var request = new PositionRequest
            {
                Description = "Lider", 
                Hierarchy = 1,
                MaxAmount = 1000,
                CompanyId = 1
            };

            //ACT
            var amountOfModifiedRegisters = await service.CreatePosition(request);

            //ASSERT
            Assert.Equal(1, amountOfModifiedRegisters);
        }

        [Fact]
        public async Task TestCreatePositionBadRequest()
        {
            //ARRANGE
            var mockQuery = new Mock<IPositionQuery>();
            var mockCommand = new Mock<IPositionCommand>();
            var validatorMock = new Mock<IValidator<PositionRequest>>();
            validatorMock.Setup(v => v.ValidateAsync(It.IsAny<PositionRequest>(), default))
                .ReturnsAsync(new ValidationResult(new List<ValidationFailure>
                {
                    new ValidationFailure("Descripcion", "La descripcion no puede estar vacia")
                })); mockCommand.Setup(command => command.InsertPosition(It.IsAny<Position>())).ReturnsAsync(1);
            var service = new PositionService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            var request = new PositionRequest
            {
                Description = "",
                Hierarchy = 1,
                MaxAmount = 1000,
                CompanyId = 1
            };

            //ACT & ASSERT
            await Assert.ThrowsAsync<BadRequestException> (async ()=> 
                await service.CreatePosition(request));
        }

        [Fact]
        public async Task TestGetPositionsByCompanyHappyWay()
        {
            //ARRANGE
            var mockQuery = new Mock<IPositionQuery>();
            var mockCommand = new Mock<IPositionCommand>();
            var validatorMock = new Mock<IValidator<PositionRequest>>();
            var list = new List<Position>();
            var response = new Position
            {
                Name = "Lider",
                Hierarchy = 1,
                MaxAmount = 1000,
                IdCompany = 1
            };
            list.Add(response);
            mockQuery.Setup(q => q.GetPositionsByCompany(It.IsAny<int>()))
                .ReturnsAsync(list);
            var service = new PositionService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            //ACT
            var resultList = await service.GetPositionsByCompany(1);

            //ASSERT
            Assert.Equal(resultList.Count, list.Count);
            var result = resultList[0];
            Assert.Equal(result.Description, response.Name);
            Assert.Equal(result.Hierarchy, response.Hierarchy);
            Assert.Equal(result.MaxAmount, response.MaxAmount);
        }


        [Fact]
        public async Task TestGetPositionsByCompanyBadRequest()
        {
            //ARRANGE
            var mockQuery = new Mock<IPositionQuery>();
            var mockCommand = new Mock<IPositionCommand>();
            var validatorMock = new Mock<IValidator<PositionRequest>>();
            var list = new List<Position>();
            mockQuery.Setup(q => q.GetPositionsByCompany(It.IsAny<int>()))
                .ReturnsAsync(list);
            var service = new PositionService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            //ACT & ASSERT
            await Assert.ThrowsAsync<BadRequestException>(async () =>
                await service.GetPositionsByCompany(-1));
        }

        [Fact]
        public async Task TestGetPositionsByCompanyEmptyList()
        {
            //ARRANGE
            var mockQuery = new Mock<IPositionQuery>();
            var mockCommand = new Mock<IPositionCommand>();
            var validatorMock = new Mock<IValidator<PositionRequest>>();
            var list = new List<Position>();
            mockQuery.Setup(q => q.GetPositionsByCompany(It.IsAny<int>()))
                .ReturnsAsync(list);
            var service = new PositionService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            //ACT
            var result = await service.GetPositionsByCompany(1);

            //ASSERT
            Assert.Equal(result.Count, list.Count);
        }

        [Fact]
        public async Task TestGetPositionEntityHappyWay()
        {
            //ARRANGE
            var mockQuery = new Mock<IPositionQuery>();
            var mockCommand = new Mock<IPositionCommand>();
            var validatorMock = new Mock<IValidator<PositionRequest>>();
            var response = new Position
            {
                Name = "Lider",
                Hierarchy = 1,
                MaxAmount = 1000,
                IdCompany = 1
            };
            mockQuery.Setup(v => v.GetPosition(It.IsAny<int>()))
                .ReturnsAsync(response);
            var service = new PositionService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            //ACT
            var result = await service.GetPositionEntity(1);

            //ASSERT
            Assert.Equal(result.Name, response.Name);
            Assert.Equal(result.Hierarchy, response.Hierarchy);
            Assert.Equal(result.MaxAmount, response.MaxAmount);
            Assert.Equal(result.IdCompany, response.IdCompany);
        }

        [Fact]
        public async Task TestGetPositionEntityNotFound()
        {
            //ARRANGE
            var mockQuery = new Mock<IPositionQuery>();
            var mockCommand = new Mock<IPositionCommand>();
            var validatorMock = new Mock<IValidator<PositionRequest>>();
            Position? response = null;
            mockQuery.Setup(v => v.GetPosition(It.IsAny<int>()))
                .ReturnsAsync(response!);
            var service = new PositionService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            //ACT && ASSERT
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await service.GetPositionEntity(1));
        }

        [Fact]
        public async Task TestGetPositionEntityBadRequest()
        {
            //ARRANGE
            var mockQuery = new Mock<IPositionQuery>();
            var mockCommand = new Mock<IPositionCommand>();
            var validatorMock = new Mock<IValidator<PositionRequest>>();
            var service = new PositionService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            //ACT && ASSERT
            await Assert.ThrowsAsync<BadRequestException>(async () =>
                await service.GetPositionEntity(-1));
        }

        [Fact]
        public async Task TestGetPositionHappyWay()
        {
            //ARRANGE
            var mockQuery = new Mock<IPositionQuery>();
            var mockCommand = new Mock<IPositionCommand>();
            var validatorMock = new Mock<IValidator<PositionRequest>>();
            var response = new Position
            {
                Name = "Lider",
                Hierarchy = 1,
                MaxAmount = 1000,
                IdCompany = 1
            };
            mockQuery.Setup(v => v.GetPosition(It.IsAny<int>()))
                .ReturnsAsync(response);
            var service = new PositionService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            //ACT
            var result = await service.GetPosition(1);

            //ASSERT
            Assert.Equal(result.Description, response.Name);
            Assert.Equal(result.Hierarchy, response.Hierarchy);
            Assert.Equal(result.MaxAmount, response.MaxAmount);
        }

        [Fact]
        public async Task TestGetPositionNotFound()
        {
            //ARRANGE
            var mockQuery = new Mock<IPositionQuery>();
            var mockCommand = new Mock<IPositionCommand>();
            var validatorMock = new Mock<IValidator<PositionRequest>>();
            Position? response = null;
            mockQuery.Setup(v => v.GetPosition(It.IsAny<int>()))
                .ReturnsAsync(response!);
            var service = new PositionService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            //ACT && ASSERT
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await service.GetPosition(1));
        }

        [Fact]
        public async Task TestGetPositionBadRequest()
        {
            //ARRANGE
            var mockQuery = new Mock<IPositionQuery>();
            var mockCommand = new Mock<IPositionCommand>();
            var validatorMock = new Mock<IValidator<PositionRequest>>();
            var service = new PositionService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            //ACT && ASSERT
            await Assert.ThrowsAsync<BadRequestException>(async () =>
                await service.GetPosition(-1));
        }

        [Fact]
        public async Task TestDeleteHappyWay()
        {
            //ARRANGE
            var mockQuery = new Mock<IPositionQuery>();
            var mockCommand = new Mock<IPositionCommand>();
            var validatorMock = new Mock<IValidator<PositionRequest>>();
            var queryResponse = new Position
            {
                Name = "Lider",
                Hierarchy = 1,
                MaxAmount = 1000,
                IdCompany = 1
            };
            mockQuery.Setup(v => v.GetPosition(It.IsAny<int>()))
                .ReturnsAsync(queryResponse);
            mockCommand.Setup(v => v.DeletePosition(It.IsAny<Position>()))
                .ReturnsAsync(1);
            var service = new PositionService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            //ACT
            var amountOfModifiedRegisters = await service.DeletePosition(1);

            //ASSERT
            Assert.Equal(1, amountOfModifiedRegisters);
        }

        [Fact]
        public async Task TestDeletePositionBadRequest()
        {
            //ARRANGE
            var mockQuery = new Mock<IPositionQuery>();
            var mockCommand = new Mock<IPositionCommand>();
            var validatorMock = new Mock<IValidator<PositionRequest>>();
            var service = new PositionService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            //ACT && ASSERT
            await Assert.ThrowsAsync<BadRequestException>(async () =>
                await service.DeletePosition(-1));
        }

        [Fact]
        public async Task TestDeletePositionNotFound()
        {
            //ARRANGE
            var mockQuery = new Mock<IPositionQuery>();
            var mockCommand = new Mock<IPositionCommand>();
            var validatorMock = new Mock<IValidator<PositionRequest>>();
            Position? response = null;
            mockQuery.Setup(v => v.GetPosition(It.IsAny<int>()))
                .ReturnsAsync(response!);
            var service = new PositionService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            //ACT && ASSERT
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await service.DeletePosition(1));
        }
    }
}
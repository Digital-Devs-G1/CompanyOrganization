using Application.DTO.Request;
using Application.DTO.Response;
using Application.Exceptions;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
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
    public class EmployeeTest
    {
        [Fact]
        public async Task TestCreateemployeeHappyWay()
        {
            //ARRANGE
            var mockQuery = new Mock<IEmployeeQuery>();
            var mockCommand = new Mock<IEmployeeCommand>();
            var mockPositionService = new Mock<IPositionService>();
            var validatorMock = new Mock<IValidator<EmployeeRequest>>();
            validatorMock.Setup(v => v.ValidateAsync(It.IsAny<EmployeeRequest>(), default))
                .ReturnsAsync(new ValidationResult());
            mockCommand.Setup(command => command.InsertEmployee(It.IsAny<Employee>())).ReturnsAsync(1);
            var service = new EmployeeService(mockCommand.Object, mockQuery.Object, mockPositionService.Object, validatorMock.Object);

            var request = new EmployeeRequest
            {
                FirsName = "Jhon",
                LastName = "Kenedy",
                DepartmentId = 2,
                SuperiorId = 2,
                PositionId = 1,
                IsApprover = false
            };

            //
            var amountOfModifiedRegisters = await service.CreateEmployee(request);

            //ASSERT
            Assert.Equal(1, amountOfModifiedRegisters);
        }

        [Fact]
        public async Task TestCreateDepartmentBadRequest()
        {
            //ARRANGE
            var mockQuery = new Mock<IEmployeeQuery>();
            var mockCommand = new Mock<IEmployeeCommand>();
            var mockPositionService = new Mock<IPositionService>();
            var validatorMock = new Mock<IValidator<EmployeeRequest>>();
            validatorMock.Setup(v => v.ValidateAsync(It.IsAny<EmployeeRequest>(), default))
                .ReturnsAsync(new ValidationResult(new List<ValidationFailure>
                {
                    new ValidationFailure("FirstName", "El Nombre no puede ser vacio")
                }));
            mockCommand.Setup(command => command.InsertEmployee(It.IsAny<Employee>())).ReturnsAsync(1);
                
            var service = new EmployeeService(mockCommand.Object, mockQuery.Object, mockPositionService.Object, validatorMock.Object);

            var request = new EmployeeRequest
            {
                Id = 1,
                FirsName = "",
                LastName = "Kenedy",
                DepartmentId = 2,
                SuperiorId = 2,
                PositionId = 1,
                IsApprover = false
            };

            //ACT & ASSERT
            await Assert.ThrowsAsync<BadRequestException> (async ()=> 
                await service.CreateEmployee(request));
        }

        [Fact]
        public async Task TestGetEmployeeDepartmentHappyWay()
        {
            //ARRANGE
            var mockQuery = new Mock<IEmployeeQuery>();
            var mockCommand = new Mock<IEmployeeCommand>();
            var mockPositionService = new Mock<IPositionService>();
            var validatorMock = new Mock<IValidator<EmployeeRequest>>();
            var response = new Department
            {
                Name = "DepartmentTest",
                IdCompany = 1
            };
            mockQuery.Setup(q => q.GetEmployeeDepartment(It.IsAny<int>()))
                .ReturnsAsync(response);
            var service = new EmployeeService(mockCommand.Object, mockQuery.Object, mockPositionService.Object, validatorMock.Object);

            //ACT
            var result = await service.GetEmployeeDepartment(1);

            //ASSERT
            Assert.Equal(result.Name, response.Name);
        }


        [Fact]
        public async Task TestGetDepartmentsByCompanyBadRequest()
        {
            //ARRANGE
            var mockQuery = new Mock<IEmployeeQuery>();
            var mockCommand = new Mock<IEmployeeCommand>();
            var mockPositionService = new Mock<IPositionService>();
            var validatorMock = new Mock<IValidator<EmployeeRequest>>();
            var response = new Department
            {
                Name = "DepartmentTest",
                IdCompany = 1
            };
            mockQuery.Setup(q => q.GetEmployeeDepartment(It.IsAny<int>()))
                .ReturnsAsync(response);
            var service = new EmployeeService(mockCommand.Object, mockQuery.Object, mockPositionService.Object, validatorMock.Object);

            //ACT & ASSERT
            await Assert.ThrowsAsync<BadRequestException>(async () =>
                await service.GetEmployeeDepartment(-1));
        }

        [Fact]
        public async Task TestGetDepartmentsByCompanyNotFound()
        {
            //ARRANGE
            var mockQuery = new Mock<IEmployeeQuery>();
            var mockCommand = new Mock<IEmployeeCommand>();
            var mockPositionService = new Mock<IPositionService>();
            var validatorMock = new Mock<IValidator<EmployeeRequest>>();
            Department? department = null!;
            mockQuery.Setup(q => q.GetEmployeeDepartment(It.IsAny<int>()))
                .ReturnsAsync(department!);
            var service = new EmployeeService(mockCommand.Object, mockQuery.Object, mockPositionService.Object, validatorMock.Object);

            //ACT & ASSERT
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await service.GetEmployeeDepartment(1));
        }

        [Fact]
        public async Task TestGetEmployeeHappyWay()
        {
            //ARRANGE
            var mockQuery = new Mock<IEmployeeQuery>();
            var mockCommand = new Mock<IEmployeeCommand>();
            var mockPositionService = new Mock<IPositionService>();
            var validatorMock = new Mock<IValidator<EmployeeRequest>>();
            var response = new Employee
            {
                Id = 1,
                FirstName = "Jhon",
                LastName = "Kenedy",
                DepartamentId = 2,
                SuperiorId = 2,
                PositionId = 1,
                IsApprover = false
            };
            mockQuery.Setup(v => v.GetEmployee(It.IsAny<int>()))
                .ReturnsAsync(response);
            var service = new EmployeeService(mockCommand.Object, mockQuery.Object, mockPositionService.Object, validatorMock.Object);

            //ACT
            var result = await service.GetEmployee(1);

            //ASSERT
            Assert.Equal(result.Id, response.Id);
            Assert.Equal(result.FirsName, response.FirstName);
            Assert.Equal(result.DepartmentId, response.DepartamentId);
            Assert.Equal(result.LastName, response.LastName);
            Assert.Equal(result.PositionId, response.PositionId);
            Assert.Equal(result.SuperiorId, response.SuperiorId);
            Assert.Equal(result.IsApprover, response.IsApprover);
        }

        [Fact]
        public async Task TestGetEmployeeNotFound()
        {
            //ARRANGE
            var mockQuery = new Mock<IEmployeeQuery>();
            var mockCommand = new Mock<IEmployeeCommand>();
            var mockPositionService = new Mock<IPositionService>();
            var validatorMock = new Mock<IValidator<EmployeeRequest>>();
            Employee? response = null;
            mockQuery.Setup(v => v.GetEmployee(It.IsAny<int>()))
                .ReturnsAsync(response!);
            var service = new EmployeeService(mockCommand.Object, mockQuery.Object, mockPositionService.Object, validatorMock.Object);

            //ACT && ASSERT
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await service.GetEmployee(1));
        }

        [Fact]
        public async Task TestGetEmployeeBadRequest()
        {
            //ARRANGE
            var mockQuery = new Mock<IEmployeeQuery>();
            var mockCommand = new Mock<IEmployeeCommand>();
            var mockPositionService = new Mock<IPositionService>();
            var validatorMock = new Mock<IValidator<EmployeeRequest>>();
            Employee? response = null;
            mockQuery.Setup(v => v.GetEmployee(It.IsAny<int>()))
                .ReturnsAsync(response!);
            var service = new EmployeeService(mockCommand.Object, mockQuery.Object, mockPositionService.Object, validatorMock.Object);

            //ACT && ASSERT
            await Assert.ThrowsAsync<BadRequestException>(async () =>
                await service.GetEmployee(-1));
        }

        [Fact]
        public async Task TestDeleteHappyWay()
        {
            //ARRANGE
            var mockQuery = new Mock<IEmployeeQuery>();
            var mockCommand = new Mock<IEmployeeCommand>();
            var mockPositionService = new Mock<IPositionService>();
            var validatorMock = new Mock<IValidator<EmployeeRequest>>();
            var response = new Employee
            {
                Id = 1,
                FirstName = "Jhon",
                LastName = "Kenedy",
                DepartamentId = 2,
                SuperiorId = 2,
                PositionId = 1,
                IsApprover = false
            };
            mockQuery.Setup(v => v.GetEmployee(It.IsAny<int>()))
                .ReturnsAsync(response);
            mockCommand.Setup(v => v.DeleteEmployee(It.IsAny<Employee>()))
                .ReturnsAsync(1);
            var service = new EmployeeService(mockCommand.Object, mockQuery.Object, mockPositionService.Object, validatorMock.Object);

            var request = new DepartmentRequest
            {
                Name = "DepartmentTest",
                IdCompany = 1
            };

            //
            var amountOfModifiedRegisters = await service.DeleteEmployee(1);

            //ASSERT
            Assert.Equal(1, amountOfModifiedRegisters);
        }

        [Fact]
        public async Task TestDeleteBadRequest()
        {
            //ARRANGE
            var mockQuery = new Mock<IEmployeeQuery>();
            var mockCommand = new Mock<IEmployeeCommand>();
            var mockPositionService = new Mock<IPositionService>();
            var validatorMock = new Mock<IValidator<EmployeeRequest>>();
            var service = new EmployeeService(mockCommand.Object, mockQuery.Object, mockPositionService.Object, validatorMock.Object);

            //ACT && ASSERT
            await Assert.ThrowsAsync<BadRequestException>(async () =>
                await service.DeleteEmployee(-1));
        }

        [Fact]
        public async Task TestDeleteNotFound()
        {
            //ARRANGE
            var mockQuery = new Mock<IEmployeeQuery>();
            var mockCommand = new Mock<IEmployeeCommand>();
            var mockPositionService = new Mock<IPositionService>();
            var validatorMock = new Mock<IValidator<EmployeeRequest>>();
            Employee? response = null;
            mockQuery.Setup(v => v.GetEmployee(It.IsAny<int>()))
                .ReturnsAsync(response!); 
            var service = new EmployeeService(mockCommand.Object, mockQuery.Object, mockPositionService.Object, validatorMock.Object);

            //ACT && ASSERT
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await service.DeleteEmployee(1));
        }

        /*
         * GetSuperiors
         * GetNextApprover
         * GetApprover
         * AcceptHistoryFlag
         * DissmisHistoryFlag
         * AcceptApprovalsFlagFlag
         * DissmisApprovalsFlag 
         */
    }
}
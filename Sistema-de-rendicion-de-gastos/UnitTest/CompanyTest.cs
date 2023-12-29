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
    public class CompanyTest
    {
        [Fact]
        public async Task CreateCompany_Ok()
        {
            //ARRANGE
            var mockQuery = new Mock<ICompanyQuery>();
            var mockCommand = new Mock<ICompanyCommand>();
            var validatorMock = new Mock<IValidator<CompanyRequest>>();
            validatorMock.Setup(v => v.ValidateAsync(It.IsAny<CompanyRequest>(), default))
                .ReturnsAsync(new ValidationResult());
            mockCommand.Setup(command => command.InsertCompany(It.IsAny<Company>())).ReturnsAsync(1);
            var service = new CompanyService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            var request = new CompanyRequest
            {
                Cuit = "1122334455",
                Name = "CompanyTest",
                Adress = "Test address",
                Phone = "5544332211"
            };

            //
            var amountOfModifiedRegisters = await service.CreateCompany(request);

            //ASSERT
            Assert.Equal(1, amountOfModifiedRegisters);
        }

        [Fact]
        public async Task CreateCompany_BadRequest()
        {
            //ARRANGE
            var mockQuery = new Mock<ICompanyQuery>();
            var mockCommand = new Mock<ICompanyCommand>();
            var validatorMock = new Mock<IValidator<CompanyRequest>>();
            validatorMock.Setup(v => v.ValidateAsync(It.IsAny<CompanyRequest>(), default))
                .ReturnsAsync(new ValidationResult(new List<ValidationFailure> 
                {
                    new ValidationFailure("Cuit", "El Cuit no puede ser vacio")
                }));
            var service = new CompanyService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            var request = new CompanyRequest
            {
                Cuit = "",
                Name = "CompanyTest",
                Adress = "Test address",
                Phone = "5544332211"
            };

            //ACT & ASSERT
            await Assert.ThrowsAsync<BadRequestException> (async ()=> 
                await service.CreateCompany(request));

            //ASSERT
        }

        [Fact]
        public async Task TestGetCompanysMethod()
        {
            //ARRANGE
            var mockQuery = new Mock<ICompanyQuery>();
            var mockCommand = new Mock<ICompanyCommand>();
            var list = new List<Company>();
            var response = new Company
            {
                Cuit = "27458965875",
                Name = "CompanyTest",
                Adress = "Test address",
                Phone = "5544332211"
            };
            list.Add(response);
            response = new Company
            {
                Cuit = "24658986584",
                Name = "CompanyTest2",
                Adress = "Test address2",
                Phone = "1122334455"
            };
            list.Add(response);
            mockQuery.Setup(v => v.GetCompanys())
                .ReturnsAsync(list);
            var validatorMock = new Mock<IValidator<CompanyRequest>>();
            var service = new CompanyService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            //ACT
            var result = await service.GetCompanys();

            //ASSERT
            Assert.Equal(result.Count, list.Count);
        }

        [Fact]
        public async Task TestGetCompanyHappyWay()
        {
            //ARRANGE
            var mockQuery = new Mock<ICompanyQuery>();
            var mockCommand = new Mock<ICompanyCommand>();
            var response = new Company
            {
                Cuit = "27458965875",
                Name = "CompanyTest",
                Adress = "Test address",
                Phone = "5544332211"
            };
            mockQuery.Setup(v => v.GetCompany(It.IsAny<int>()))
                .ReturnsAsync(response);
            var validatorMock = new Mock<IValidator<CompanyRequest>>();
            var service = new CompanyService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            //ACT
            var result = await service.GetCompany(1);

            //ASSERT
            Assert.Equal(result.Cuit, response.Cuit);
            Assert.Equal(result.Name, response.Name);
            Assert.Equal(result.Adress, response.Adress);
            Assert.Equal(result.Phone, response.Phone);
        }

        [Fact]
        public async Task TestGetCompanyNotFound()
        {
            //ARRANGE
            var mockQuery = new Mock<ICompanyQuery>();
            var mockCommand = new Mock<ICompanyCommand>();
            var validatorMock = new Mock<IValidator<CompanyRequest>>();
            Company? response = null;
            mockQuery.Setup(v => v.GetCompany(It.IsAny<int>()))
                .ReturnsAsync(response!);
            var service = new CompanyService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            //ACT && ASSERT
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await service.GetCompany(1));
        }
    }
}
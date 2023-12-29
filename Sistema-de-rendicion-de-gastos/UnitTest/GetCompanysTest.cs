using Application.DTO.Request;
using Application.Exceptions;
using Application.Interfaces.IRepositories;
using Application.UseCases;
using FluentAssertions.Common;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace UnitTest
{
    public class GetCompanysTest
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
            var service = new CompanyService(mockQuery.Object, mockCommand.Object, validatorMock.Object);

            var request = new CompanyRequest
            {
                Cuit = "1122334455",
                Name = "CompanyTest",
                Adress = "Test address",
                Phone = "5544332211"
            };

            //ACT
            await service.CreateCompany(request);

            //ASSERT
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
    }
}
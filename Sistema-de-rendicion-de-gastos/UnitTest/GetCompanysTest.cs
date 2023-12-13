using Application.DTO.Request;
using Application.Interfaces.IRepositories;
using Application.UseCases;
using FluentAssertions.Common;
using FluentValidation;
using Moq;

namespace UnitTest
{
    public class GetCompanysTest
    {
        [Fact]
        public async Task Test1()
        {
            //ARRANGE
            var mockQuery = new Mock<ICompanyQuery>();
            var mockCommand = new Mock<ICompanyCommand>();
            var mockValidator = new Mock<IValidator<CompanyRequest>>();
            var service = new CompanyService(mockQuery.Object, mockCommand.Object, mockValidator.Object);

            var request = new CompanyRequest
            {
                Cuit = "1122334455",
                Name = "CompanyTest",
                Adress = "Test address",
                Phone = "5544332211"
            };

            int expectedLenght = 1;

            //ACT
            await service.CreateCompany(request);
            var companys = await service.GetCompanys();

            //ASSERT
            Assert.Equal(expectedLenght, companys.Count);

        }
    }
}
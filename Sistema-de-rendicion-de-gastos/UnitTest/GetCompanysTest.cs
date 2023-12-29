using Application.DTO.Request;
using Application.Exceptions;
using Application.Interfaces.IRepositories;
using Application.UseCases;
using Domain.Entities;
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

        //Entiendo que la finalidad del mock es para evitar dejar rastros.
        //Mi test usa un objeto que se instancia con un query, un command y un validator.
        //Se valida un metodo de dicho objeto que solo usa el validator y el command.
        //En ese caso, ¿ deberia usar lo siguiente ?:
        //* Un mock para el query porque no es usado por el metodo.
        //* Un mock para el command, evitando que modifique la base de datos.
        //* El validator original, ya que no deja rastros y me permite testear mejor el comportamiento.
        //Si el metodo usara el query, ¿en dicho caso me convendria enviarle el query real y no un mock, ya que no modifica la base de datos y me permite testear mejor el comportamiento?

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
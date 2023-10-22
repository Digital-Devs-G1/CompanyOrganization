using Application.DTO.Creator;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Exceptions;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Application.UseCases
{
    public class EmployeeService : IEmployeeService
    {

        private readonly EmployeeCreator _creator;
        private readonly IEmployeeCommand _command;
        private readonly IEmployeeQuery _repository;
        private readonly IValidator<EmployeeRequest> _validator;

        public EmployeeService(IEmployeeCommand command, IEmployeeQuery repository, IValidator<EmployeeRequest> validator) 
        {
            _repository = repository;
            _creator = new EmployeeCreator();
            _command = command;
            _validator = validator;
        }

        public async Task<List<EmployeeResponse>> GetEmployees()
        {
            List<EmployeeResponse> list = new List<EmployeeResponse>();

            IEnumerable<Employee> entities = await _repository.GetEmployees();

            foreach (Employee entity in entities)
            {
                list.Add(_creator.Create(entity));
            }

            return list;
        }

        public async Task<EmployeeResponse> GetEmployee(int employeeId)
        {
            Employee entity = await _repository.GetEmployee(employeeId);

            if(entity == null)
                throw new NotFoundException("El empleado no existe.");

            return _creator.Create(entity);
        }

        public async Task CreateEmployee(EmployeeRequest request)
        {

            ValidationResult validatorResult = await _validator.ValidateAsync(request);

            if(!validatorResult.IsValid)
                throw new BadRequestException("Empleado Invalido", validatorResult);
            

            Employee employee = new Employee
            {
               Id = request.Id,
               FirstName = request.FirsName,
               LastName = request.FirsName,
               DepartamentId = request.DepartmentId,
               SuperiorId = request.SuperiorId,
               PositionId = request.PositionId,
            };

            await _command.InsertEmployee(employee);
        }

        public async Task<DepartmentResponse> GetDepartmentByIdUser(int idUser)
        {
            Department entity = await _repository.GetDepartmentByIdUser(idUser);

            DepartmentResponse response = new DepartmentResponse()
            {
                DepartmentId = entity.Id,
                Name = entity.Name
            };

            return response;
        }
    }
}
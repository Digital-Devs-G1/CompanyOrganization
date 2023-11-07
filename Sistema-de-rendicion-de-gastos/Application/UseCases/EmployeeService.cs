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
               LastName = request.LastName,
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


        public async Task<int> GetNextApprover(int employeeId, int amount)
        {
            if (employeeId < 1)
                throw new BadRequestException("usuario invalido");

            Employee employee = await _repository.GetEmployee(employeeId);

            if (employee == null)
                throw new NotFoundException("usuario invalido");

            if (employee.Position.MaxAmount >= amount)
                return 0;

            return (int)((employee.SuperiorId == null) ? 0 : employee.SuperiorId);
        }

        public async Task<int> GetApprover(int id)
        {
            if(id < 1)
                throw new BadRequestException("usuario invalido");

            Employee entity = await _repository.GetEmployee(id);
            
            if(entity == null)
                throw new NotFoundException("usuario invalido");

            //decimal MaxAmountSuperior = entity.Superior.Position.MaxAmount;

            // si devolvemos el mismo id del superior significa que es el que lo puede aprobar.
            /*if(MaxAmountSuperior >= monto || entity.Superior.SuperiorId == null) // devolvemos el ultimo en la cadena, el cual puede ser el superior directo pormas q no lo pueda aprobar.
                return entity.SuperiorId;
            //throw new BadRequestException("Superior puede aprobar el monto solicitado.");
*/
            //return await this.NextApprover(entity*.SuperiorId, monto);
            return (int)((entity.SuperiorId == null) ? 0 : entity.SuperiorId);
        }

        public async Task DeleteEmployee(int id)
        {
            Employee entity = await _repository.GetEmployee(id);

            if(entity == null)
                throw new BadRequestException("empleado invalido");

            await _command.DeleteEmployee(entity);
        }

        public async Task AcceptHistoryFlag(int id)
        {
            Employee entity = await _repository.GetEmployee(id);

            if(entity == null)
                throw new BadRequestException("empleado invalido");

            await _command.AcceptHistoryFlag(entity);
        }

        public async Task DissmisHistoryFlag(int id)
        {
            Employee entity = await _repository.GetEmployee(id);

            if(entity == null)
                throw new BadRequestException("empleado invalido");

            await _command.DissmisHistoryFlag(entity);

        }

        public async Task AcceptApprovalsFlagFlag(int id)
        {
            Employee entity = await _repository.GetEmployee(id);

            if(entity == null)
                throw new BadRequestException("empleado invalido");

            await _command.AcceptApprovalsFlagFlag(entity);
        }

        public async Task DissmisApprovalsFlag(int id)
        {
            Employee entity = await _repository.GetEmployee(id);

            if(entity == null)
                throw new BadRequestException("empleado invalido");

            await _command.DissmisApprovalsFlag(entity);
        }
    }
}
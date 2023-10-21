using Application.DTO.Creator;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
{
    public class EmployeeService : IEmployeeService
    {

        private readonly EmployeeCreator _creator;
        private readonly IEmployeeCommand _command;
        private readonly IEmployeeQuery _repository;

        public EmployeeService(IEmployeeCommand command, IEmployeeQuery repository) 
        {
            _repository = repository;
            _creator = new EmployeeCreator();
            _command = command;
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
            if (entity != null)
                return _creator.Create(entity);
            return null;
        }
        public async Task<Employee> CreateEmployee(EmployeeRequest request)
        {
            //var employee = new Employee
            //{
            //    JobId = request.JobId,
            //    UserId = request.UserId,
            //    FirsName = request.FirsName,
            //    LastName = request.LastName,
            //    Phone = request.Phone,
            //    Sex = request.Sex,
            //    CivilStatus = request.CivilStatus,
            //    Dni = request.Dni
            //};
            //await _command.InsertEmployee(employee);
            return new Employee();
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
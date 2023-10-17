using Application.DTO.Creator;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Exceptions;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
{
    public class  DepartmentService : IDepartmentService
    {
        private readonly IDepartmentQuery _query;
        private readonly IDepartmentCommand _command;
        private readonly DepartmentCreator _creator;

        public DepartmentService(IDepartmentQuery repository, IDepartmentCommand command)
        {
            _query = repository;
            _creator = new DepartmentCreator();
            _command = command;
        }

        public async Task<IList<DepartmentResponse>> GetDepartments()
        {
            IList<DepartmentResponse> list = new List<DepartmentResponse>();
            IList<Department> entities = await _query.GetDepartments();

            foreach (Department entity in entities)
            {
                list.Add(_creator.Create(entity));
            }

            return list;
        }

        public async Task<DepartmentResponse> GetDepartment(int departmentId)
        {
            Department entity = await _query.GetDepartment(departmentId);

            if(entity == null)
                throw new NotFoundException("El departamento no existe.");

            return _creator.Create(entity);
        }

        public async Task<Department> CreateDepartment(DepartmentRequest request)
        {

            var department = new Department
            { 
                Name= request.Name
            };

           await _command.InsertDepartment(department);

           return department;
        }
    }
}

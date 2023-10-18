using Application.DTO.Creator;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;
using System.ComponentModel.Design;

namespace Application.UseCases
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentQuery _repository;
        private IDepartmentCommand _command;
        private DepartmentCreator _creator;

        public DepartmentService(IDepartmentQuery repository, IDepartmentCommand command)
        {
            _repository = repository;
            _creator = new DepartmentCreator();
            _command = command;
        }

        public async Task<IList<DepartmentResponse>> GetDepartments()
        {
            IList<DepartmentResponse> list = new List<DepartmentResponse>();
            IList<Department> entities = await _repository.GetDepartments();
            foreach (Department entity in entities)
            {
                list.Add(_creator.Create(entity));
            }
            return list;
        }

        public async Task<DepartmentResponse>? GetDepartment(int departmentId)
        {
            Department? entity = await _repository.GetDepartment(departmentId);
            if (entity != null)
                return _creator.Create(entity);
            return null;
        }
        public async Task<Department> CreateDepartment(DepartmentRequest request)
        {
            var department = new Department
            {
                Name = request.Name
            };
            await _command.InsertDepartment(department);
            return department;
        }
    }
}
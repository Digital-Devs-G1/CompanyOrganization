using Application.DTO.Creator;
using Application.DTO.Response;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;
using System.ComponentModel.Design;

namespace Application.UseCases
{
    public class  DepartmentService : IDepartmentService
    {
        private IDepartmentQuery _repository;
        private DepartmentCreator _creator;

        public DepartmentService(IDepartmentQuery repository)
        {
            _repository = repository;
            _creator = new DepartmentCreator();
        }

        public IList<DepartmentResponse> GetDepartments()
        {
            IList<DepartmentResponse> list = new List<DepartmentResponse>();
            IList<Department> entities = _repository.GetDepartments();
            foreach (Department entity in entities)
            {
                list.Add(_creator.Create(entity));
            }
            return list;
        }
        public DepartmentResponse? GetCompany(int departmentId)
        {
            Department? entity = _repository.GetDepartment(departmentId);
            if(entity != null)
               return _creator.Create(entity);
            return null;            
        }

        public DepartmentResponse? GetDepartment(int departmentId)
        {
            Department? entity = _repository.GetDepartment(departmentId);
            if (entity != null)
                return _creator.Create(entity);
            return null;
        }
    }
}

using Application.DTO.Response;

namespace Application.Interfaces.IServices
{
    public interface IDepartmentService
    {
        public IList<DepartmentResponse> GetDepartments();
        public DepartmentResponse? GetDepartment(int departmentId); 
    }
}

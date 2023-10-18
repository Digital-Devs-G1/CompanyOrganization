using Application.DTO.Response;
using Domain.Entities;

namespace Application.DTO.Creator
{
    public class EmployeeCreator
    {
        public EmployeeResponse Create(Employee employee)
        {
            return new EmployeeResponse()
            {
                EmployeeId = employee.EmployeeId,
                JobId = employee.JobId,
                UserId = employee.UserId,
                FirsName = employee.FirsName,
                LastName = employee.LastName,
                Phone = employee.Phone,
                Sex = employee.Sex,
                CivilStatus = employee.CivilStatus,
                Dni = employee.Dni,
            };
        }
    }
}
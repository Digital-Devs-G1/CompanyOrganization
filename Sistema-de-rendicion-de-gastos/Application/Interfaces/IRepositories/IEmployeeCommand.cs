using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IEmployeeCommand
    {
        Task AcceptApprovalsFlagFlag(Employee entity);
        Task AcceptHistoryFlag(Employee entity);
        Task DeleteEmployee(Employee employee);
        Task DissmisApprovalsFlag(Employee entity);
        Task DissmisHistoryFlag(Employee entity);
        Task InsertEmployee(Employee employee);
    }
}

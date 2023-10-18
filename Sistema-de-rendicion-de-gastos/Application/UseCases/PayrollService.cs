using Application.DTO.Creator;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
{
    public class PayrollService : IPayrollService
    {
        private IPayrollQuery _repository;
        private PayrollCreator _creator;
        private IPayrollCommand _command;
        public PayrollService(IPayrollQuery repository, IPayrollCommand command)
        {
            _repository = repository;
            _creator = new PayrollCreator();
            _command = command;
        }
        public async Task<IList<PayrollResponse>> GetPayrolls()
        {
            IList<PayrollResponse> list = new List<PayrollResponse>();
            IList<Payroll> entities = await _repository.GetPayrolls();
            foreach (Payroll entity in entities)
            {
                list.Add(_creator.Create(entity));
            }
            return list;
        }
        public async Task<PayrollResponse>? GetPayroll(int payrollId)
        {
            Payroll? entity = await _repository.GetPayroll(payrollId);
            if (entity != null)
                return _creator.Create(entity);
            return null;
        }
        public async Task<Payroll> CreatePayroll(PayrollRequest request)
        {
            var payroll = new Payroll
            {
                CompanyId = request.CompanyId,
                DepartmentId = request.DepartmentId,
                PositionId = request.PositionId,
                EmployeeId = request.EmployeeId
            };
            await _command.InsertPayroll(payroll);
            return payroll;
        }
    }
}

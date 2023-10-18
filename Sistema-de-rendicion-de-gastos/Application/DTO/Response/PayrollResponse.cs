using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response
{
    public class PayrollResponse
    {
        public int PayrollId { get; set; }
        public required int CompanyId { get; set; }
        public required int DepartmentId { get; set; }
        public required int PositionId { get; set; }
        public required int EmployeeId { get; set; }
    }
}
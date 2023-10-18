using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request
{
    public class PayrollRequest
    {
        public required int CompanyId { get; set; }
        public required int DepartmentId { get; set; }
        public required int PositionId { get; set; }
        public required int EmployeeId { get; set; }
    }
}

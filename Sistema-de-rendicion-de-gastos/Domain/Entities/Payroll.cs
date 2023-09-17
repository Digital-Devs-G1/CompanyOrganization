using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payroll
    {
        public int PayrollId { get; set; }
        public required int CompanyId { get; set; }
        public Company? CompanyNav { get; set; }
        public required int DepartmentId { get; set; }
        public Department? DepartmentNav { get; set; }

    }
}

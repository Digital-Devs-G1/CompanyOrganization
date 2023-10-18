﻿
namespace Domain.Entities
{
    public class Payroll
    {
        public int PayrollId { get; set; }
        public required int CompanyId { get; set; }
        public Company? CompanyNav { get; set; }
        public required int DepartmentId { get; set; }
        public Department? DepartmentNav { get; set; }
        public required int PositionId { get; set; }
        public Position? PositionNav { get; set; }
        public required int EmployeeId { get; set; }
        public Employee? EmployeeNav { get; set; }
    }
}

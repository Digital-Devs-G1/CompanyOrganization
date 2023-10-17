namespace Domain.Entities
{
    public class Payroll
    {
        public int PayrollId { get; set; }
        public int CompanyId { get; set; }
        public Company CompanyNav { get; set; }
        public int DepartmentId { get; set; }
        public Department DepartmentNav { get; set; }
    }
}

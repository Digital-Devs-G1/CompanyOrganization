
namespace Domain.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public required string Name { get; set; }
        public int CompanyCuit { get; set; }
        public Company? CompanyNav { get; set; }
    }

}


namespace Domain.Entities
{
    public class Company
    {
        public int Cuit { get; set; }
        public required string Name { get; set; }
        public required string Adress { get; set; }
        public int Tel { get; set; }
        public ICollection<Department>? Departments { get; set; }

    }

}

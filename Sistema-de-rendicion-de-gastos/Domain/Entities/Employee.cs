using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int JobId { get; set; }
        public int UserId { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
        public string CivilStatus { get; set; }
        public int Dni { get; set; }
    }
}

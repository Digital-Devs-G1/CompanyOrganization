using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request
{
    public class EmployeeRequest
    {
        public required int JobId { get; set; }
        public required int UserId { get; set; }
        public required string FirsName { get; set; }
        public required string LastName { get; set; }
        public required string Phone { get; set; }
        public required string Sex { get; set; }
        public required string CivilStatus { get; set; }
        public required int Dni { get; set; }
    }
}

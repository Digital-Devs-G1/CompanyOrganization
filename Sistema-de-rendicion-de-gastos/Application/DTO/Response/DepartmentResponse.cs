using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response
{
    public class DepartmentResponse
    {
        public int DepartmentId { get; set; }
        public required string Name { get; set; }

    }
}

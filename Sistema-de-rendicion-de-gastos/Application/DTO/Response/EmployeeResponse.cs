﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public int PositionId { get; set; }
        public int? SuperiorId { get; set; }
        public int DepartmentId { get; set; }
  
    }
}

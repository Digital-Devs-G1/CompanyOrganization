using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request
{
    public class PositionRequest
    {
        public required string Description { get; set; }
        public required int Hierarchy { get; set; }
        public required int MaxMonthlyAmount { get; set; }
    }
}

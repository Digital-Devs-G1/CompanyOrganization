﻿
namespace Domain.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public required string Cuit { get; set; }
        public required string Name { get; set; }
        public required string Adress { get; set; }
        public required string Phone { get; set; }
        
    }

}

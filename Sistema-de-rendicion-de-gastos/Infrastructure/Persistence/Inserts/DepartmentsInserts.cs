using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Inserts
{
    public class DepartmentInserts : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(new Department()
            {
                DepartmentId = 1,
                Name = "Recursos Humanos",
            },
            new Department()
            {
                DepartmentId = 2,
                Name = "Marketing",
            },
            new Department()
            {
                DepartmentId = 3,
                Name = "Comercial",
            },
            new Department()
            {
                DepartmentId = 4,
                Name = "Control de Gestión",
            },
            new Department()
            {
                DepartmentId = 5,
                Name = "Logística y Operaciones",
            });
        }
    }
}

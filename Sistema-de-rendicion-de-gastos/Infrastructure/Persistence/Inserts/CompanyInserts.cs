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
    public class CompanyInserts : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(new Company()
            {
                CompanyId = 1,
                Cuit = "30-69730872-1",
                Name = "Easy SRL",
                Adress = "Av. Calchaquí 3950",
                Phone = "4229-4000"
            },
            new Company()
            {
                CompanyId = 2,
                Cuit = "33-70892523-9",
                Name = "Remax",
                Adress = "Av. Rivadavia 430",
                Phone = "4253-4987"
            },
            new Company()
            {
                CompanyId = 3,
                Cuit = "30-67940701-1",
                Name = "Papelera el Vasquito",
                Adress = "Av. La Plata 1932",
                Phone = "4280-5775"
            },
            new Company()
            {
                CompanyId = 4,
                Cuit = "30-56102989-6",
                Name = "Simonetti Constructora",
                Adress = "Almte. Brown 281",
                Phone = "4224-0363"
            },
            new Company()
            {
                CompanyId = 5,
                Cuit = "30-51199267-9",
                Name = "El bosque",
                Adress = "Av. La Plata 3401",
                Phone = "7539-8916"
            });
        }
    }
}

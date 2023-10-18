using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Inserts
{
    public class EmployeeInserts : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                    new Employee()
                    {
                        EmployeeId = 1,
                        JobId = 0,
                        UserId = 1,
                        FirsName = "Gustavo",
                        LastName = "Garcia Krahn",
                        Phone = "12345678",
                        Sex = "Hombre",
                        CivilStatus = "Soltero",
                        Dni = 41345678
                    },
                    new Employee()
                    {
                        EmployeeId = 2,
                        JobId = 1,
                        UserId = 2,
                        FirsName = "Javier",
                        LastName = "Perez",
                        Phone = "12345679",
                        Sex = "Hombre",
                        CivilStatus = "Soltero",
                        Dni = 34654321
                    },
                    new Employee()
                    {
                        EmployeeId = 3,
                        JobId = 2,
                        UserId = 3,
                        FirsName = "Josefa",
                        LastName = "Scoll",
                        Phone = "12345678",
                        Sex = "Mujer",
                        CivilStatus = "Soltero",
                        Dni = 52156489
                    },
                    new Employee()
                    {
                        EmployeeId = 4,
                        JobId = 3,
                        UserId = 4,
                        FirsName = "Pedro",
                        LastName = "Rodriguez",
                        Phone = "12345678",
                        Sex = "Hombre",
                        CivilStatus = "Soltero",
                        Dni = 38654978
                    },
                    new Employee()
                    {
                        EmployeeId = 5,
                        JobId = 2,
                        UserId = 5,
                        FirsName = "Fernando",
                        LastName = "Suarez",
                        Phone = "12123489",
                        Sex = "Hombre",
                        CivilStatus = "Casado",
                        Dni = 40654978
                    },
                    new Employee()
                    {
                        EmployeeId = 6,
                        JobId = 2,
                        UserId = 6,
                        FirsName = "Jesus",
                        LastName = "Paez",
                        Phone = "95123489",
                        Sex = "Hombre",
                        CivilStatus = "Soltero",
                        Dni = 43854978
                    },
                    new Employee()
                    {
                        EmployeeId = 7,
                        JobId = 2,
                        UserId = 7,
                        FirsName = "Pablo",
                        LastName = "Papalia",
                        Phone = "12123489",
                        Sex = "Hombre",
                        CivilStatus = "Casado",
                        Dni = 42754978
                    },
                    new Employee()
                    {
                        EmployeeId = 8,
                        JobId = 2,
                        UserId = 8,
                        FirsName = "Alfredo",
                        LastName = "Baez",
                        Phone = "12123489",
                        Sex = "Hombre",
                        CivilStatus = "Casado",
                        Dni = 35454978
                    },
                    new Employee()
                    {
                        EmployeeId = 9,
                        JobId = 2,
                        UserId = 9,
                        FirsName = "Silvia",
                        LastName = "Cardozo",
                        Phone = "65823489",
                        Sex = "Mujer",
                        CivilStatus = "Casado",
                        Dni = 42654978
                    },
                    new Employee()
                    {
                        EmployeeId = 10,
                        JobId = 2,
                        UserId = 10,
                        FirsName = "Jesica",
                        LastName = "Sirio",
                        Phone = "52493489",
                        Sex = "Mujer",
                        CivilStatus = "Casado",
                        Dni = 3854978
                    },
                    new Employee()
                    {
                        EmployeeId = 11,
                        JobId = 2,
                        UserId = 11,
                        FirsName = "Ana",
                        LastName = "Michel",
                        Phone = "2468489",
                        Sex = "Mujer",
                        CivilStatus = "Casado",
                        Dni = 65754978
                    });
        }
    }
}


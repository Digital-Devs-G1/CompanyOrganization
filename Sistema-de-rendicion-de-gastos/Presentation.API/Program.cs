
using Application.DTO.Response;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Application.UseCases;
//using Application.UseCases;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Commands;
using Infrastructure.Repositories.Querys;
using Microsoft.EntityFrameworkCore;

namespace Presentation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<ReportsDbContext>();
            builder.Services.AddTransient<ICompanyQuery, CompanyQuery>();
            builder.Services.AddTransient<ICompanyService, CompanyService>();
            builder.Services.AddSingleton<IDepartmentQuery, DepartmentQuery>();
            builder.Services.AddSingleton<IDepartmentService, DepartmentService>();
            builder.Services.AddSingleton<IDepartmentCommand, DepartmentCommand>();
            builder.Services.AddSingleton<ICompanyCommand, CompanyCommand>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            //Run(app.Services);

        }

        public static void Run(IServiceProvider services)
        {
            while (true)
            {
                //var service = services.GetService<IVariableFieldService>();
                //Console.Write("Ingrese el numero de template: ");
                //int i = int.Parse(Console.ReadLine());
                //IList<VariableFieldResponse> fields = service.GetTemplate(i);
                //Console.WriteLine("\nRendicion de gatos:\n-------------------\n");
                //foreach (VariableFieldResponse field in fields)
                //{
                //    Console.Write(field.Label + ": ");
                //    Console.ReadLine();
                //}
                //Console.WriteLine("\nSu Reporte se ingreso con exito\n");

                ////Instanciar un DbContext
                //var db = new ReportsDbContext();
                ////Instanciar command usando el DbContext
                //var query = new DepartmentQuery(db);
                //var command = new DepartmentCommand(db);
                ////Llamar al metodo implementado
                ////Console.WriteLine(command.PostDepartment());
                ////Instanciar el servicio inyectando el command
                ////llamar al metodo postDepartment
                //var service = new DepartmentService(query,command);
                //Console.WriteLine(service.PostDepartment());
                //Console.ReadLine();

            }
        }
    }
}

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

            builder.Services.AddSingleton<IEmployeeQuery, EmployeeQuery>();
            builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
            builder.Services.AddSingleton<IPositionQuery, PositionQuery>();
            builder.Services.AddSingleton<IPositionService, PositionService>();
            builder.Services.AddSingleton<IPayrollQuery, PayrollQuery>();
            builder.Services.AddSingleton<IPayrollService, PayrollService>();

            builder.Services.AddSingleton<IEmployeeCommand, EmployeeCommand>();
            builder.Services.AddSingleton<IPositionCommand, PositionCommand>();
            builder.Services.AddSingleton<IPayrollCommand, PayrollCommand>();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }

        public static void Run(IServiceProvider services)
        {
            while (true)
            {
                //var service = services.GetService<IVariableFieldService>();
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.Write("Ingrese el numero de template: ");
                //int i = int.Parse(Console.ReadLine());
                //IList<VariableFieldResponse> fields = service.GetTemplate(i);
                //Console.ForegroundColor = ConsoleColor.Yellow;
                //Console.WriteLine("\nRendicion de gatos:\n-------------------\n");
                //Console.ForegroundColor = ConsoleColor.White;
                //foreach (VariableFieldResponse field in fields)
                //{
                //    Console.Write(field.Label + ": ");
                //    Console.ReadLine();
                //}
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine("\nSu Reporte se ingreso con exito\n");

                //Instanciar un DbContext
        //        var db = new ReportsDbContext();
                //Instanciar command usando el DbContext
        //        var query = new CompanyQuery(db);
                //Llamar al metodo implementado
                //Console.WriteLine(query.GetCompany(1)[0].Adress);
                //Instanciar el servicio inyectando el command
                //llamar al metodo getcompany
        //        var service = new CompanyService(query);
        //        Console.WriteLine(service.GetCompanys()[0].Adress);
        //        Console.ReadLine();

            }
        }
    }
}
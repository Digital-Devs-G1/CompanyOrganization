using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GGKV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cuit = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirsName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CivilStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Hierarchy = table.Column<int>(type: "int", nullable: false),
                    MaxMonthlyAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "Payrolls",
                columns: table => new
                {
                    PayrollId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payrolls", x => x.PayrollId);
                    table.ForeignKey(
                        name: "FK_Payrolls_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companys",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payrolls_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payrolls_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payrolls_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companys",
                columns: new[] { "CompanyId", "Adress", "Cuit", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Av. Calchaquí 3950", "30-69730872-1", "Easy SRL", "4229-4000" },
                    { 2, "Av. Rivadavia 430", "33-70892523-9", "Remax", "4253-4987" },
                    { 3, "Av. La Plata 1932", "30-67940701-1", "Papelera el Vasquito", "4280-5775" },
                    { 4, "Almte. Brown 281", "30-56102989-6", "Simonetti Constructora", "4224-0363" },
                    { 5, "Av. La Plata 3401", "30-51199267-9", "El bosque", "7539-8916" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, "Recursos Humanos" },
                    { 2, "Marketing" },
                    { 3, "Comercial" },
                    { 4, "Control de Gestión" },
                    { 5, "Logística y Operaciones" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "CivilStatus", "Dni", "FirsName", "JobId", "LastName", "Phone", "Sex", "UserId" },
                values: new object[,]
                {
                    { 1, "Soltero", 41345678, "Gustavo", 0, "Garcia Krahn", "12345678", "Hombre", 1 },
                    { 2, "Soltero", 34654321, "Javier", 1, "Perez", "12345679", "Hombre", 2 },
                    { 3, "Soltero", 52156489, "Josefa", 2, "Scoll", "12345678", "Mujer", 3 },
                    { 4, "Soltero", 38654978, "Pedro", 3, "Rodriguez", "12345678", "Hombre", 4 },
                    { 5, "Casado", 40654978, "Fernando", 2, "Suarez", "12123489", "Hombre", 5 },
                    { 6, "Soltero", 43854978, "Jesus", 2, "Paez", "95123489", "Hombre", 6 },
                    { 7, "Casado", 42754978, "Pablo", 2, "Papalia", "12123489", "Hombre", 7 },
                    { 8, "Casado", 35454978, "Alfredo", 2, "Baez", "12123489", "Hombre", 8 },
                    { 9, "Casado", 42654978, "Silvia", 2, "Cardozo", "65823489", "Mujer", 9 },
                    { 10, "Casado", 3854978, "Jesica", 2, "Sirio", "52493489", "Mujer", 10 },
                    { 11, "Casado", 65754978, "Ana", 2, "Michel", "2468489", "Mujer", 11 }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "PositionId", "Description", "Hierarchy", "MaxMonthlyAmount" },
                values: new object[,]
                {
                    { 1, "Socio", 1, 500000 },
                    { 2, "Director", 10, 50000 },
                    { 3, "Gerente", 20, 10000 },
                    { 4, "Supervisor", 30, 1000 },
                    { 5, "Lider", 40, 100 }
                });

            migrationBuilder.InsertData(
                table: "Payrolls",
                columns: new[] { "PayrollId", "CompanyId", "DepartmentId", "EmployeeId", "PositionId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1 },
                    { 2, 1, 2, 2, 2 },
                    { 3, 1, 1, 3, 3 },
                    { 4, 1, 2, 4, 3 },
                    { 5, 1, 1, 5, 4 },
                    { 6, 2, 2, 6, 4 },
                    { 7, 1, 1, 7, 4 },
                    { 8, 1, 1, 8, 5 },
                    { 9, 1, 1, 9, 5 },
                    { 10, 1, 2, 10, 5 },
                    { 11, 2, 1, 11, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_CompanyId",
                table: "Payrolls",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_DepartmentId",
                table: "Payrolls",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_EmployeeId",
                table: "Payrolls",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_PositionId",
                table: "Payrolls",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payrolls");

            migrationBuilder.DropTable(
                name: "Companys");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}

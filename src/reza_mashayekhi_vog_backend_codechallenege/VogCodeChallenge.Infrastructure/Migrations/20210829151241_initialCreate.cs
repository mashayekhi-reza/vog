using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VogCodeChallenge.Infrastructure.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    JobTitle = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CompanyId",
                table: "Departments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.InsertData(table: "Companies", columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("1A46D0D0-77B9-4BCF-89EB-0196017D1676"), "Vog" });

            migrationBuilder.InsertData(table: "Departments", columns: new[] { "Id", "Name", "Address", "CompanyId" },
                values: new object[] { new Guid("439FAD1B-0872-4A9F-88AB-479879168740"), "IT", "Here", 
                    new Guid("1A46D0D0-77B9-4BCF-89EB-0196017D1676") });

            migrationBuilder.InsertData(table: "Departments", columns: new[] { "Id", "Name", "Address", "CompanyId" },
                values: new object[] { new Guid("A8B39757-9C80-4E47-A458-A83BF3D32BD1"), "Sales", "There",
                    new Guid("1A46D0D0-77B9-4BCF-89EB-0196017D1676") });

            migrationBuilder.InsertData(table: "Employees", columns: new[] { "Id", "FirstName", "LastName", "Address", "JobTitle", "DepartmentId" },
                values: new object[] { new Guid("50469503-1314-480E-933A-DAD399CC5024"), "John", "Doe", "Street 1", "Sales Person 1",
                    new Guid("A8B39757-9C80-4E47-A458-A83BF3D32BD1") });

            migrationBuilder.InsertData(table: "Employees", columns: new[] { "Id", "FirstName", "LastName", "Address", "JobTitle", "DepartmentId" },
                values: new object[] { new Guid("1376C076-C3C6-4CFE-BD26-5AFBC46E8ABF"), "Jean", "Doe", "Street 2", "Sales Person 2",
                    new Guid("A8B39757-9C80-4E47-A458-A83BF3D32BD1") });

            migrationBuilder.InsertData(table: "Employees", columns: new[] { "Id", "FirstName", "LastName", "Address", "JobTitle", "DepartmentId" },
                values: new object[] { new Guid("7FFF1471-6D6E-4FE7-9496-DA9C88D56926"), "John", "Smith", "Street 3", "IT Developer 1",
                    new Guid("439FAD1B-0872-4A9F-88AB-479879168740") });

            migrationBuilder.InsertData(table: "Employees", columns: new[] { "Id", "FirstName", "LastName", "Address", "JobTitle", "DepartmentId" },
                values: new object[] { new Guid("158DCBC5-E5DC-4897-864B-65747552238A"), "Peter", "White", "Street 4", "IT Tester 1",
                    new Guid("439FAD1B-0872-4A9F-88AB-479879168740") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}

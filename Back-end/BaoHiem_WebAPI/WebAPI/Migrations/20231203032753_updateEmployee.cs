using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updateEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28857028-8cbe-43e3-ba81-3c7519be0462");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "478a7d26-77c9-484e-9250-d059e041f85f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d77636c-7a1e-4bb2-b1b8-5dccacc9dee4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e150783f-10d4-488c-a59b-1ae0ebca7c05");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDay",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "IdentifycationNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ebb8ebf-09fd-4272-a3a5-b77a3e58fa9e", "09e0d0ca-80e2-4d73-933c-d8b3add2bead", "Administrator", "ADMINISTRATOR" },
                    { "6993d906-b294-41ec-b33d-f383f2ab347a", "00b102e0-4ce1-44fc-9567-8ae701e428f4", "Manager", "MANAGER" },
                    { "89d66afb-51b1-4c99-b756-1045a97e4307", "9be4f655-b207-4d41-9cb0-2443bc89c33c", "Employee", "EMPLOYEE" },
                    { "fa188490-5e89-4de1-96fa-244cc35f51e7", "cd9a2845-c0e3-406b-902d-99a080a4ee18", "Customer", "CUSTOMER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees",
                column: "EmployeeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ebb8ebf-09fd-4272-a3a5-b77a3e58fa9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6993d906-b294-41ec-b33d-f383f2ab347a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89d66afb-51b1-4c99-b756-1045a97e4307");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa188490-5e89-4de1-96fa-244cc35f51e7");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CreateDay",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IdentifycationNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28857028-8cbe-43e3-ba81-3c7519be0462", "07dbb5b4-edb1-455d-ab2d-8528c9093f4e", "Manager", "MANAGER" },
                    { "478a7d26-77c9-484e-9250-d059e041f85f", "5074a092-e0fd-4838-912c-2543d07e662b", "Administrator", "ADMINISTRATOR" },
                    { "8d77636c-7a1e-4bb2-b1b8-5dccacc9dee4", "55c0251a-9752-465a-9d75-e427f339fad5", "Customer", "CUSTOMER" },
                    { "e150783f-10d4-488c-a59b-1ae0ebca7c05", "b2c0544e-0e32-491f-820b-a05b92d81bf3", "Employee", "EMPLOYEE" }
                });
        }
    }
}

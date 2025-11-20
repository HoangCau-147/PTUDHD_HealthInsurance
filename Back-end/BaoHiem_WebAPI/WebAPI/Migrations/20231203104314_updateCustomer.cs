using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updateCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDay",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "IdentifycationNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08021294-e34b-49d0-9a33-03eff2eba24a", "e54c29b9-e642-4b5a-8265-9546da9b2460", "Administrator", "ADMINISTRATOR" },
                    { "2ea6c305-3b9b-4426-b75d-1d9bca4ddba5", "17addc5c-ad86-4a20-9ef4-13cabac73239", "Employee", "EMPLOYEE" },
                    { "47c43e95-4b1b-4be0-ba74-0b68aa3fb770", "ebaa3c2f-04d3-47ea-bafe-769263b21150", "Customer", "CUSTOMER" },
                    { "e1f399e2-1f42-4652-a22d-4dca8c11cb2c", "4e8a4a3f-afbf-4deb-b4c9-2ba702b3a51f", "Manager", "MANAGER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08021294-e34b-49d0-9a33-03eff2eba24a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ea6c305-3b9b-4426-b75d-1d9bca4ddba5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47c43e95-4b1b-4be0-ba74-0b68aa3fb770");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1f399e2-1f42-4652-a22d-4dca8c11cb2c");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreateDay",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IdentifycationNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

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
        }
    }
}

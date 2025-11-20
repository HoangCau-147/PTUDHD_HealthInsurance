using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updateclaiminvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38cb42a6-b727-4ded-bbf9-e8122f98dfc9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6927872d-f143-44bd-af09-fe838768b948");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1ff69f5-5927-401c-8455-584978a84ff1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd84939b-d354-4a8f-9b9c-9377b1852c69");

            migrationBuilder.AlterColumn<float>(
                name: "TotalCost",
                table: "ClaimPayment",
                type: "real",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "ClaimPayment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "ClaimPayment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "TotalCost",
                table: "ClaimInvoice",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4aef86d1-c8e2-4872-a725-7524480b2233", "45fe0301-c2c7-4318-896d-e7f7ab7e6486", "Customer", "CUSTOMER" },
                    { "d91f013a-be44-48ae-8394-0c60c27cbe82", "7683e2a8-0d61-4f87-bc6c-daee9144e942", "Administrator", "ADMINISTRATOR" },
                    { "e701d161-0051-48c8-ac56-d22eca1ba365", "44ce9aba-855f-4878-8c6a-ba3d9d232ce8", "Manager", "MANAGER" },
                    { "eee03081-e667-4bcd-a23e-c43e37425e7b", "512c72f7-a2e2-4883-af16-532490c0faeb", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimPayment_EmployeeId",
                table: "ClaimPayment",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimPayment_Employees_EmployeeId",
                table: "ClaimPayment",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimPayment_Employees_EmployeeId",
                table: "ClaimPayment");

            migrationBuilder.DropIndex(
                name: "IX_ClaimPayment_EmployeeId",
                table: "ClaimPayment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aef86d1-c8e2-4872-a725-7524480b2233");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d91f013a-be44-48ae-8394-0c60c27cbe82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e701d161-0051-48c8-ac56-d22eca1ba365");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eee03081-e667-4bcd-a23e-c43e37425e7b");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "ClaimPayment");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "ClaimPayment");

            migrationBuilder.AlterColumn<int>(
                name: "TotalCost",
                table: "ClaimPayment",
                type: "int",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TotalCost",
                table: "ClaimInvoice",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38cb42a6-b727-4ded-bbf9-e8122f98dfc9", "75677283-6ea5-4167-8a43-362b117d1495", "Customer", "CUSTOMER" },
                    { "6927872d-f143-44bd-af09-fe838768b948", "30a3de38-654d-4daa-a1bb-3e67f4a043b0", "Employee", "EMPLOYEE" },
                    { "a1ff69f5-5927-401c-8455-584978a84ff1", "29ccc003-fe73-4164-931e-8a4595cc2936", "Manager", "MANAGER" },
                    { "fd84939b-d354-4a8f-9b9c-9377b1852c69", "47021db0-4431-4617-a55e-9ac63705135b", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

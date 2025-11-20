using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updatecontractId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimRequests_Employees_EmployeeID",
                table: "ClaimRequests");

            migrationBuilder.DropIndex(
                name: "IX_ClaimRequests_EmployeeID",
                table: "ClaimRequests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22a68c4c-2c86-4da5-8bf7-e3a477052b50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c9dd93b-f767-446c-8698-2c7ed17b23a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97fb4312-3dc7-440c-94b0-29fc23364c92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8f7f1ef-2fbe-4862-8c17-e407bfebbc4f");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "ClaimRequests");

            migrationBuilder.RenameColumn(
                name: "paymentMethod",
                table: "ClaimPayment",
                newName: "PaymentMethod");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03c84532-e9c7-4d70-859e-772e432fdd9f", "e466de1a-129c-4168-8cb4-e31ce01ed613", "Customer", "CUSTOMER" },
                    { "48e6b800-fa8b-4e3a-912e-c04b5a2c1824", "d3e9a4cb-075a-4d04-83ed-9e610eda2e62", "Manager", "MANAGER" },
                    { "7aee3b14-b337-43a3-a6d5-314b9b4c2520", "cf936be0-fb29-4cf0-9706-76122e9c9385", "Employee", "EMPLOYEE" },
                    { "a4e1002d-f064-49a0-a999-e187f5f2522f", "d547a276-871b-4981-ab81-4bc143f251fd", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03c84532-e9c7-4d70-859e-772e432fdd9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48e6b800-fa8b-4e3a-912e-c04b5a2c1824");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7aee3b14-b337-43a3-a6d5-314b9b4c2520");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4e1002d-f064-49a0-a999-e187f5f2522f");

            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "ClaimPayment",
                newName: "paymentMethod");

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeID",
                table: "ClaimRequests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22a68c4c-2c86-4da5-8bf7-e3a477052b50", "d4a4b636-5946-4f10-85bf-f630e8f2e741", "Customer", "CUSTOMER" },
                    { "2c9dd93b-f767-446c-8698-2c7ed17b23a6", "4fc0734b-ea1c-442e-ab3f-f1a2c919b8ee", "Manager", "MANAGER" },
                    { "97fb4312-3dc7-440c-94b0-29fc23364c92", "bc3d419f-d3a4-46e3-99f3-51271c7065cd", "Employee", "EMPLOYEE" },
                    { "c8f7f1ef-2fbe-4862-8c17-e407bfebbc4f", "877cbc39-0947-46ce-9b36-acc8ac7aa156", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimRequests_EmployeeID",
                table: "ClaimRequests",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimRequests_Employees_EmployeeID",
                table: "ClaimRequests",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}

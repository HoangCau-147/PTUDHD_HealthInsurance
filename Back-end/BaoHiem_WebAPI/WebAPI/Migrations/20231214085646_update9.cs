using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class update9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Customers_CustomerID",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Employees_EmployeeID",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_InsuranceProducts_InsuranceProductId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_InsurancePrograms_InsuranceProgramId",
                table: "Contracts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "014ef029-7563-4b6c-b086-f28908560acf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78e94446-38d1-4978-bc1d-6755fff99aa3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e701968-173f-46bd-b8a7-1765eee279f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f336fd8d-4058-4601-809f-91a7f38d2577");

            migrationBuilder.AlterColumn<float>(
                name: "TotalPrice",
                table: "Contracts",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<Guid>(
                name: "InsuranceProgramId",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "InsuranceProductId",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeID",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerID",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d4d07ae8-ba59-42c4-b20a-15a8f0a6b003", "a30f0579-8948-4b90-92a6-812b7e08a04e", "Manager", "MANAGER" },
                    { "dc02e73a-4da1-4495-b8a3-7b1d6496c786", "d4e91589-4b57-4810-85ba-1ab24f536969", "Customer", "CUSTOMER" },
                    { "de111084-c0ad-4bb5-b9ba-da0a3966f65f", "4eb235b4-4b9e-4e62-8b01-62bd580a24f6", "Employee", "EMPLOYEE" },
                    { "ff3be2f1-150a-449b-97e9-259eb14764a1", "8ab5212b-8515-46cd-a5a6-9a6109b6ba0b", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Customers_CustomerID",
                table: "Contracts",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Employees_EmployeeID",
                table: "Contracts",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_InsuranceProducts_InsuranceProductId",
                table: "Contracts",
                column: "InsuranceProductId",
                principalTable: "InsuranceProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_InsurancePrograms_InsuranceProgramId",
                table: "Contracts",
                column: "InsuranceProgramId",
                principalTable: "InsurancePrograms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Customers_CustomerID",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Employees_EmployeeID",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_InsuranceProducts_InsuranceProductId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_InsurancePrograms_InsuranceProgramId",
                table: "Contracts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4d07ae8-ba59-42c4-b20a-15a8f0a6b003");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc02e73a-4da1-4495-b8a3-7b1d6496c786");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de111084-c0ad-4bb5-b9ba-da0a3966f65f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff3be2f1-150a-449b-97e9-259eb14764a1");

            migrationBuilder.AlterColumn<float>(
                name: "TotalPrice",
                table: "Contracts",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InsuranceProgramId",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InsuranceProductId",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeID",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerID",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "014ef029-7563-4b6c-b086-f28908560acf", "80ac067f-e25e-4756-9052-494f67bafd06", "Manager", "MANAGER" },
                    { "78e94446-38d1-4978-bc1d-6755fff99aa3", "1de64d64-7823-42cc-9698-61f69c18cdfe", "Employee", "EMPLOYEE" },
                    { "8e701968-173f-46bd-b8a7-1765eee279f6", "bca45306-6c5c-4099-aebb-b7eb4d08ee2b", "Administrator", "ADMINISTRATOR" },
                    { "f336fd8d-4058-4601-809f-91a7f38d2577", "eb70f83a-1643-4f9b-83d2-2c5c1deccf80", "Customer", "CUSTOMER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Customers_CustomerID",
                table: "Contracts",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Employees_EmployeeID",
                table: "Contracts",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_InsuranceProducts_InsuranceProductId",
                table: "Contracts",
                column: "InsuranceProductId",
                principalTable: "InsuranceProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_InsurancePrograms_InsuranceProgramId",
                table: "Contracts",
                column: "InsuranceProgramId",
                principalTable: "InsurancePrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

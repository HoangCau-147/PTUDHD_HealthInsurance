using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updatecontractinvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3462e295-36aa-49d5-9e09-0612b6944f07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0121459-23d3-4838-932b-f3736ccb2794");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcf93e4c-c214-4914-8fb1-4ddfd9be578d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f16b1463-17ee-4fbb-af41-d87ec2d579e7");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "ContractsInvoice");

            migrationBuilder.AlterColumn<float>(
                name: "LastPrice",
                table: "ContractsInvoice",
                type: "real",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ContractsInvoice",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "LastPrice",
                table: "ContractsInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ContractsInvoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "ContractsInvoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3462e295-36aa-49d5-9e09-0612b6944f07", "d071413f-0cf3-4fb4-bb33-18d92875da54", "Employee", "EMPLOYEE" },
                    { "c0121459-23d3-4838-932b-f3736ccb2794", "7befdb5a-aa4b-4d70-8eb3-44cd618d7c12", "Administrator", "ADMINISTRATOR" },
                    { "dcf93e4c-c214-4914-8fb1-4ddfd9be578d", "9cdd00e2-9276-4ae1-8180-7febcf49a44a", "Customer", "CUSTOMER" },
                    { "f16b1463-17ee-4fbb-af41-d87ec2d579e7", "ac7dc6b8-4559-4858-b53b-1ad36cb42bd3", "Manager", "MANAGER" }
                });
        }
    }
}

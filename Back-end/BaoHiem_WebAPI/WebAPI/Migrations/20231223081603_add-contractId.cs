using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class addcontractId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "133de218-b3b7-4be7-8576-0a033591a872", "dcb5c988-58a3-489f-87cb-1b2eb5763319", "Administrator", "ADMINISTRATOR" },
                    { "67550add-bef6-48af-8801-088e9290959e", "2aecaf8d-a985-4869-a5b9-065b11343128", "Manager", "MANAGER" },
                    { "8f190131-9931-4458-a756-6041166f6120", "a6dcef42-94ec-4180-8ffc-a343c227e1f2", "Customer", "CUSTOMER" },
                    { "edfcd409-884b-4f27-a73d-4f25475785cd", "08a91efb-d0b1-4be1-8a9a-d2c81ab8ad86", "Employee", "EMPLOYEE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "133de218-b3b7-4be7-8576-0a033591a872");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67550add-bef6-48af-8801-088e9290959e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f190131-9931-4458-a756-6041166f6120");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edfcd409-884b-4f27-a73d-4f25475785cd");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Contracts");

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
    }
}

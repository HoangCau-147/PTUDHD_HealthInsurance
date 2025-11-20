using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updatecontractaddconfirmdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16b23a39-b361-48a0-9666-96d020d5b874");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b772407-5ac8-42e4-8f99-341731256fce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91027f26-5178-4904-aa11-c8bc9c211c41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9662f35a-168a-4cbf-b63d-a5688cbfa0ad");

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmDate",
                table: "Contracts",
                type: "datetime2",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ConfirmDate",
                table: "Contracts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16b23a39-b361-48a0-9666-96d020d5b874", "b2f6654f-e84a-44b2-8f24-28f03d1a954d", "Employee", "EMPLOYEE" },
                    { "6b772407-5ac8-42e4-8f99-341731256fce", "47475842-8486-47b6-aa76-44507bd17a77", "Manager", "MANAGER" },
                    { "91027f26-5178-4904-aa11-c8bc9c211c41", "d20f86d3-db0a-4900-8478-0e4ec2630a09", "Administrator", "ADMINISTRATOR" },
                    { "9662f35a-168a-4cbf-b63d-a5688cbfa0ad", "7803fcbb-88f1-42ba-8cb3-70ceb44df858", "Customer", "CUSTOMER" }
                });
        }
    }
}

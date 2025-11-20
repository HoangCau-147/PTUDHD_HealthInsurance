using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class modifieduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11f73de9-b78f-4740-97bc-9f2d4f9b3d9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85f5cb93-d3be-4ea4-b976-dbe2f8fdbb73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac077d30-1736-4e13-b33e-2fbdad8f3a6a");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3866100e-3ece-4eb9-b777-7b6d3f8ca777", "5aad6dfd-f861-4e36-81fe-9a83d61fff07", "Administrator", "ADMINISTRATOR" },
                    { "9a15772c-3f8c-4587-8b38-a9d70cc819b6", "5aac5a7d-b123-4927-b120-5465e9fa272f", "Manager", "MANAGER" },
                    { "c23ac149-cdcf-49e0-8c8c-5764c87fa1d7", "43a626a5-fec8-49ba-98ca-1bb291595470", "Employee", "EMPLOYEE" },
                    { "ee502b2a-9fd6-431c-8b22-be440b8cc566", "c4e39593-03da-425b-b487-b3018f26c1a5", "Customer", "CUSTOMER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3866100e-3ece-4eb9-b777-7b6d3f8ca777");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a15772c-3f8c-4587-8b38-a9d70cc819b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c23ac149-cdcf-49e0-8c8c-5764c87fa1d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee502b2a-9fd6-431c-8b22-be440b8cc566");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "11f73de9-b78f-4740-97bc-9f2d4f9b3d9f", "bc74f89b-3af7-46cc-8394-20349851f22a", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "85f5cb93-d3be-4ea4-b976-dbe2f8fdbb73", "5bf6de12-e362-4e6e-a010-e995e700f990", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac077d30-1736-4e13-b33e-2fbdad8f3a6a", "7a9046a7-98e4-487f-a8f7-9711230ba2af", "Administrator", "ADMINISTRATOR" });
        }
    }
}

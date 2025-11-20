using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class addnewrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updteproductstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9005cc58-667e-45bb-897d-55151c3affcf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f6ec010-2810-4e76-b91b-c891cb1ed1c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bec7cff7-b3ee-4938-9bbd-c877732f3920");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb9f2d1e-9c80-4f6f-b5ec-0106f28b0844");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4002ccda-eee3-451f-bfc1-2fd2e8c590d5", "13d25e56-4cba-4f3a-949d-e4de053f646e", "Employee", "EMPLOYEE" },
                    { "4d86709e-fd75-4190-9b5f-c723972c549d", "e95722ff-c475-40ff-847b-61eed5257e54", "Manager", "MANAGER" },
                    { "69503958-43a3-4045-8f45-ab305830839e", "e6af2ba7-6702-4502-a622-ca4426c127a1", "Administrator", "ADMINISTRATOR" },
                    { "a39bf69c-ed55-421a-9a3f-2065c3c563ff", "f05977af-c5ab-43b2-a698-d51a6ffb8286", "Customer", "CUSTOMER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4002ccda-eee3-451f-bfc1-2fd2e8c590d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d86709e-fd75-4190-9b5f-c723972c549d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69503958-43a3-4045-8f45-ab305830839e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a39bf69c-ed55-421a-9a3f-2065c3c563ff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9005cc58-667e-45bb-897d-55151c3affcf", "fa9f18a2-58ad-420d-9a9d-0928534227dc", "Customer", "CUSTOMER" },
                    { "9f6ec010-2810-4e76-b91b-c891cb1ed1c3", "6c4db3e3-5128-450a-b764-6d4fa7b74445", "Manager", "MANAGER" },
                    { "bec7cff7-b3ee-4938-9bbd-c877732f3920", "8780017c-caa3-4341-86ee-b8c52a7cc627", "Administrator", "ADMINISTRATOR" },
                    { "eb9f2d1e-9c80-4f6f-b5ec-0106f28b0844", "178258df-d6e1-414c-8fb0-f662c0301030", "Employee", "EMPLOYEE" }
                });
        }
    }
}

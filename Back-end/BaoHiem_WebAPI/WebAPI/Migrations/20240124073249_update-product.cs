using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updateproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "InsuranceProducts",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Status",
                table: "InsuranceProducts");

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
        }
    }
}

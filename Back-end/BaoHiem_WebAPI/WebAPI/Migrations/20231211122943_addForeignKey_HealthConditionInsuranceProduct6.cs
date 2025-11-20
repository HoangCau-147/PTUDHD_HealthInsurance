using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class addForeignKey_HealthConditionInsuranceProduct6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48182d06-26a3-4062-a8d8-7f69d598de4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69afac31-76a4-4006-ae69-74f77f445f2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2a9d174-a74d-41ba-b759-3158fceaa38c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f74ceb50-42e6-41f0-866e-bd007ed20a0f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "277d4b41-526b-4c84-964c-a6c791a7dfb2", "ed7c4582-2c17-4237-b837-a3538b280303", "Administrator", "ADMINISTRATOR" },
                    { "6df76355-c399-44d0-ad7d-11387835e198", "93989789-5383-4f0a-9fe3-dc548c5cf162", "Customer", "CUSTOMER" },
                    { "9c338f64-5784-4c18-8314-fa5fb9ccab31", "a3e30e98-7188-433b-b70b-4bd96c7248dc", "Employee", "EMPLOYEE" },
                    { "db7e9a43-86c7-47ca-9518-6c5c99919568", "1c5f4bb7-0ee3-4ca2-8c2f-5969b2d237e2", "Manager", "MANAGER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "277d4b41-526b-4c84-964c-a6c791a7dfb2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6df76355-c399-44d0-ad7d-11387835e198");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c338f64-5784-4c18-8314-fa5fb9ccab31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db7e9a43-86c7-47ca-9518-6c5c99919568");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48182d06-26a3-4062-a8d8-7f69d598de4a", "dcb270b1-df2d-4d2c-b5c4-f10d9a5d16a6", "Employee", "EMPLOYEE" },
                    { "69afac31-76a4-4006-ae69-74f77f445f2e", "19ea4cb0-f621-49fc-9caf-fc1b33247649", "Administrator", "ADMINISTRATOR" },
                    { "a2a9d174-a74d-41ba-b759-3158fceaa38c", "30ebb510-e1cc-465c-b01c-e7cda5c63e37", "Manager", "MANAGER" },
                    { "f74ceb50-42e6-41f0-866e-bd007ed20a0f", "fa732912-558a-4128-b6dd-6312387d35b3", "Customer", "CUSTOMER" }
                });
        }
    }
}

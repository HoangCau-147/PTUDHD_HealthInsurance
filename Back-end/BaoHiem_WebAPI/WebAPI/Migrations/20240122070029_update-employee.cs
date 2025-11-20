using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updateemployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41147a54-fcb6-4d21-8532-1733d70368fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fa55f0c-2929-4bd2-81b8-e33917c4d0c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66e1f5a7-78ee-48b0-af2f-99b4b83175cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94475814-5640-4d4a-b190-5458e0ec79ae");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "56e08eb9-054d-40f9-aa65-4a8de9378f20", "835a6ee0-e7ea-489e-b095-84a5455424e9", "Manager", "MANAGER" },
                    { "5f26b3f7-e26d-49e1-b739-6663edb23841", "5c58e72c-96f2-4201-897a-b263e0ce44b3", "Customer", "CUSTOMER" },
                    { "88ff3774-8914-43e5-a36d-1f7417a3e810", "5eb05ac0-ef8f-40c3-a03d-7515ac72eedd", "Administrator", "ADMINISTRATOR" },
                    { "95a5d769-2ff8-4bee-a0d2-85bd779a5737", "96ac48bf-0615-402a-bd57-fa702a4112e9", "Employee", "EMPLOYEE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56e08eb9-054d-40f9-aa65-4a8de9378f20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f26b3f7-e26d-49e1-b739-6663edb23841");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ff3774-8914-43e5-a36d-1f7417a3e810");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95a5d769-2ff8-4bee-a0d2-85bd779a5737");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41147a54-fcb6-4d21-8532-1733d70368fb", "4f35992b-06a4-4e8f-b42a-77e28f1aa824", "Customer", "CUSTOMER" },
                    { "4fa55f0c-2929-4bd2-81b8-e33917c4d0c8", "a365f006-7423-452a-b0c4-4effee9e4bfa", "Manager", "MANAGER" },
                    { "66e1f5a7-78ee-48b0-af2f-99b4b83175cd", "69c56c27-939d-4915-9e81-ce12b62e6e49", "Administrator", "ADMINISTRATOR" },
                    { "94475814-5640-4d4a-b190-5458e0ec79ae", "8d30ff9c-001f-430d-b1de-8d9e1c917535", "Employee", "EMPLOYEE" }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a3476b6-0195-4827-b773-cb0c89cb9ad0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b0ebeff-ece4-4b02-94ec-46f1f1d94add");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0dec5e6-7900-4ef4-88bb-812535812adb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed94f2b6-d4e5-423d-ab33-c79af367a63c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0811383e-f839-4b24-8413-3a8b14ac4f9f", "ee3ab292-18f1-4889-b674-7b897cf53009", "Manager", "MANAGER" },
                    { "63a36f62-39f2-4df1-af65-e2f13aa2f96e", "895c0877-134e-4841-8546-0177c9c85181", "Customer", "CUSTOMER" },
                    { "abe0d001-06c3-4ace-b56a-1a00a57bdfdf", "6d6f56ea-5f03-43a0-8667-a7ceb11c2430", "Employee", "EMPLOYEE" },
                    { "e35a42ff-ac82-4acd-82a5-8753741f402a", "dd5e59cc-477d-4bf9-8a6d-fbf08e62ab3e", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0811383e-f839-4b24-8413-3a8b14ac4f9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63a36f62-39f2-4df1-af65-e2f13aa2f96e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abe0d001-06c3-4ace-b56a-1a00a57bdfdf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e35a42ff-ac82-4acd-82a5-8753741f402a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a3476b6-0195-4827-b773-cb0c89cb9ad0", "2eb5b69d-82f1-42c4-b2b5-2a201ce8ede1", "Customer", "CUSTOMER" },
                    { "6b0ebeff-ece4-4b02-94ec-46f1f1d94add", "c6271381-89de-44d2-a825-6006af9d811c", "Manager", "MANAGER" },
                    { "a0dec5e6-7900-4ef4-88bb-812535812adb", "657b47e9-fcf9-4228-9143-f0cf58a37712", "Administrator", "ADMINISTRATOR" },
                    { "ed94f2b6-d4e5-423d-ab33-c79af367a63c", "15957f3c-7995-4725-b02e-2b263ea82b1f", "Employee", "EMPLOYEE" }
                });
        }
    }
}

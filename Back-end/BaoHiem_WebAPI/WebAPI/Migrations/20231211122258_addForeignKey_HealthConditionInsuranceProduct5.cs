using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class addForeignKey_HealthConditionInsuranceProduct5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "223d05a3-7bbb-413e-87d6-6eb0336f422b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c242d90-4544-409c-9ba6-411518b900d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b7fe923-d1ea-47a5-8b64-33afb19684bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8f1b2f0-0c94-4abf-934c-f145775c3127");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "223d05a3-7bbb-413e-87d6-6eb0336f422b", "431efdaf-0ef1-4d50-982e-b742b124ceb8", "Administrator", "ADMINISTRATOR" },
                    { "4c242d90-4544-409c-9ba6-411518b900d1", "ba66cbd8-b68d-42fe-bf56-7b51528ff0c8", "Employee", "EMPLOYEE" },
                    { "5b7fe923-d1ea-47a5-8b64-33afb19684bc", "ff0e2a4a-f689-46e8-aca5-1457a4b07d5b", "Manager", "MANAGER" },
                    { "d8f1b2f0-0c94-4abf-934c-f145775c3127", "a5b1adeb-ff1f-4403-b6d6-02ba77c2b2ce", "Customer", "CUSTOMER" }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class addForeignKey_HealthConditionInsuranceProduct4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22356e80-3f45-4348-b72b-49919605a561");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "629b9eac-68a4-4bdf-849b-cc2425528184");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca2bf4e2-f2ff-48eb-b6cd-aa5e33affdd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed910351-f737-4249-bea4-7816a8f5b0ee");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "22356e80-3f45-4348-b72b-49919605a561", "0e403009-8fa0-4741-8eac-6fcc57f0d93c", "Administrator", "ADMINISTRATOR" },
                    { "629b9eac-68a4-4bdf-849b-cc2425528184", "5ab6ddbb-eb45-47a2-ad7e-ce97fb0aa2f6", "Manager", "MANAGER" },
                    { "ca2bf4e2-f2ff-48eb-b6cd-aa5e33affdd4", "37542cf7-fedb-4ce8-a999-dbfa91b4bac0", "Customer", "CUSTOMER" },
                    { "ed910351-f737-4249-bea4-7816a8f5b0ee", "522129e6-7799-4777-8498-e173093dcdf3", "Employee", "EMPLOYEE" }
                });
        }
    }
}

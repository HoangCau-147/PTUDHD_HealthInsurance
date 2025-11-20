using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class addForeignKey_HealthConditionInsuranceProduct3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36eb7fd1-aa01-4b77-9896-1891d506a433");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5435d323-dcb6-4474-8f08-9a9916266231");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63665792-3b9b-4d59-bcce-66e54b8e7ee8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af1d6325-de3b-4adf-b327-aeddd62de923");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "36eb7fd1-aa01-4b77-9896-1891d506a433", "8155ce5f-07ba-4af4-bbf7-4a25b11a6aa5", "Customer", "CUSTOMER" },
                    { "5435d323-dcb6-4474-8f08-9a9916266231", "9622dd76-780f-40ca-bd2a-22d755400ab5", "Manager", "MANAGER" },
                    { "63665792-3b9b-4d59-bcce-66e54b8e7ee8", "274dbc08-a601-4cef-a035-4f7cc779db12", "Administrator", "ADMINISTRATOR" },
                    { "af1d6325-de3b-4adf-b327-aeddd62de923", "591ab3ea-cd23-4cd4-8540-3d268de023be", "Employee", "EMPLOYEE" }
                });
        }
    }
}

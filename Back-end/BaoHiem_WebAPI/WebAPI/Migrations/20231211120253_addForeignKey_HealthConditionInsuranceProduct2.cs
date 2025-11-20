using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class addForeignKey_HealthConditionInsuranceProduct2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_healthConditionInsuranceProducts_InsuranceProducts_InsuranceProductId",
                table: "healthConditionInsuranceProducts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "018474b2-6ee8-411c-970b-6de11a67923e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "595d469b-0d33-4dd9-b5ee-6c3657089f0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c3f30a4-0400-48fd-b1b3-8a098503a4ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e381a86-7c77-4f32-8705-6d4b85ee6c5d");

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

            migrationBuilder.AddForeignKey(
                name: "FK_healthConditionInsuranceProducts_InsuranceProducts_InsuranceProductId",
                table: "healthConditionInsuranceProducts",
                column: "InsuranceProductId",
                principalTable: "InsuranceProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_healthConditionInsuranceProducts_InsuranceProducts_InsuranceProductId",
                table: "healthConditionInsuranceProducts");

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
                    { "018474b2-6ee8-411c-970b-6de11a67923e", "30a9c90e-3611-4af6-9af1-23c86f5c1d3e", "Administrator", "ADMINISTRATOR" },
                    { "595d469b-0d33-4dd9-b5ee-6c3657089f0f", "b6c06e4c-7437-4947-9814-9d33153bef51", "Employee", "EMPLOYEE" },
                    { "7c3f30a4-0400-48fd-b1b3-8a098503a4ff", "689018c5-051d-4a33-b9e6-622194aba39d", "Manager", "MANAGER" },
                    { "7e381a86-7c77-4f32-8705-6d4b85ee6c5d", "2ed7d5fc-1b90-4379-9b48-55a1c7250e56", "Customer", "CUSTOMER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_healthConditionInsuranceProducts_InsuranceProducts_InsuranceProductId",
                table: "healthConditionInsuranceProducts",
                column: "InsuranceProductId",
                principalTable: "InsuranceProducts",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class addForeignKey_HealthConditionInsuranceProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_healthConditionInsuranceProducts_HealthConditions_HealthConditionId",
                table: "healthConditionInsuranceProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_healthConditionInsuranceProducts_InsuranceProducts_InsuranceProductId",
                table: "healthConditionInsuranceProducts");

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
                    { "018474b2-6ee8-411c-970b-6de11a67923e", "30a9c90e-3611-4af6-9af1-23c86f5c1d3e", "Administrator", "ADMINISTRATOR" },
                    { "595d469b-0d33-4dd9-b5ee-6c3657089f0f", "b6c06e4c-7437-4947-9814-9d33153bef51", "Employee", "EMPLOYEE" },
                    { "7c3f30a4-0400-48fd-b1b3-8a098503a4ff", "689018c5-051d-4a33-b9e6-622194aba39d", "Manager", "MANAGER" },
                    { "7e381a86-7c77-4f32-8705-6d4b85ee6c5d", "2ed7d5fc-1b90-4379-9b48-55a1c7250e56", "Customer", "CUSTOMER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_healthConditionInsuranceProducts_HealthConditions_HealthConditionId",
                table: "healthConditionInsuranceProducts",
                column: "HealthConditionId",
                principalTable: "HealthConditions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_healthConditionInsuranceProducts_InsuranceProducts_InsuranceProductId",
                table: "healthConditionInsuranceProducts",
                column: "InsuranceProductId",
                principalTable: "InsuranceProducts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_healthConditionInsuranceProducts_HealthConditions_HealthConditionId",
                table: "healthConditionInsuranceProducts");

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
                    { "0811383e-f839-4b24-8413-3a8b14ac4f9f", "ee3ab292-18f1-4889-b674-7b897cf53009", "Manager", "MANAGER" },
                    { "63a36f62-39f2-4df1-af65-e2f13aa2f96e", "895c0877-134e-4841-8546-0177c9c85181", "Customer", "CUSTOMER" },
                    { "abe0d001-06c3-4ace-b56a-1a00a57bdfdf", "6d6f56ea-5f03-43a0-8667-a7ceb11c2430", "Employee", "EMPLOYEE" },
                    { "e35a42ff-ac82-4acd-82a5-8753741f402a", "dd5e59cc-477d-4bf9-8a6d-fbf08e62ab3e", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_healthConditionInsuranceProducts_HealthConditions_HealthConditionId",
                table: "healthConditionInsuranceProducts",
                column: "HealthConditionId",
                principalTable: "HealthConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_healthConditionInsuranceProducts_InsuranceProducts_InsuranceProductId",
                table: "healthConditionInsuranceProducts",
                column: "InsuranceProductId",
                principalTable: "InsuranceProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

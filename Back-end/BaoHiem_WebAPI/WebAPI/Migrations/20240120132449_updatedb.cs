using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00e62c29-0f8b-4f03-b080-5fe6cd5b7c5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a7fedd2-b225-42a2-8a9d-3a89c5997c0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b51e695-8ce0-40cb-a176-5a9ab479a512");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a89fe856-cfd1-4024-b898-004393caef0f");

            migrationBuilder.DropColumn(
                name: "MedicalCondition",
                table: "ClaimRequests");

            migrationBuilder.DropColumn(
                name: "MedicalHistory",
                table: "ClaimRequests");

            migrationBuilder.AddColumn<string>(
                name: "HospitalBillAmount",
                table: "ClaimRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "HospitalBillAmount",
                table: "ClaimRequests");

            migrationBuilder.AddColumn<string>(
                name: "MedicalCondition",
                table: "ClaimRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicalHistory",
                table: "ClaimRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00e62c29-0f8b-4f03-b080-5fe6cd5b7c5b", "123fe5ee-4e65-4266-9949-ff5db63c6222", "Administrator", "ADMINISTRATOR" },
                    { "3a7fedd2-b225-42a2-8a9d-3a89c5997c0d", "2f712ebc-a0cc-40fd-bc29-6f0313e873bf", "Employee", "EMPLOYEE" },
                    { "8b51e695-8ce0-40cb-a176-5a9ab479a512", "27f2c858-5137-4e94-88d6-e5a46f69f125", "Manager", "MANAGER" },
                    { "a89fe856-cfd1-4024-b898-004393caef0f", "5ee6a57d-e03a-4f00-b88e-bfe6a4a48be3", "Customer", "CUSTOMER" }
                });
        }
    }
}

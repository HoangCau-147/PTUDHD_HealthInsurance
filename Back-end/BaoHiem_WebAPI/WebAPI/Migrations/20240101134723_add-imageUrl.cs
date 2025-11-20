using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class addimageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8efc0fe3-0b81-4c57-ba9a-ef077a23695c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a88bd7c6-1001-4de4-b73e-8c4a3cd90e6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9260796-a67d-4a1a-8daf-e8012e7b33de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1f7e336-b355-499f-8973-1af72e7a662b");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "ClaimPayment");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "InsuranceProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03c0bbe6-1549-408c-8089-7a1dd0834983", "aae42d7b-bc51-4fc6-92f2-aa741e332304", "Customer", "CUSTOMER" },
                    { "ab8e167a-0059-4673-b892-316f1b5a14c7", "d7686fee-b030-4782-9791-5ce4188a46dc", "Administrator", "ADMINISTRATOR" },
                    { "c0ef6ab2-edb0-42e0-a006-84781138189e", "bb161185-d45f-4789-881a-bb0cff3d8918", "Employee", "EMPLOYEE" },
                    { "f1d7aefd-0378-4845-a503-706c506a5d18", "edb1b906-1b9b-41ad-860f-e411b153a3c8", "Manager", "MANAGER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03c0bbe6-1549-408c-8089-7a1dd0834983");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab8e167a-0059-4673-b892-316f1b5a14c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0ef6ab2-edb0-42e0-a006-84781138189e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1d7aefd-0378-4845-a503-706c506a5d18");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "InsuranceProducts");

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "ClaimPayment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8efc0fe3-0b81-4c57-ba9a-ef077a23695c", "1d24f74a-28d6-4037-9a35-fb18e9d1eb89", "Administrator", "ADMINISTRATOR" },
                    { "a88bd7c6-1001-4de4-b73e-8c4a3cd90e6c", "82316e4d-581e-4af0-a67d-499cd69a14cb", "Employee", "EMPLOYEE" },
                    { "a9260796-a67d-4a1a-8daf-e8012e7b33de", "fe71cf5b-a5f2-4dea-931f-4900991a31b2", "Manager", "MANAGER" },
                    { "d1f7e336-b355-499f-8973-1af72e7a662b", "300e0dba-05a7-48aa-9ab7-bd7925cbf826", "Customer", "CUSTOMER" }
                });
        }
    }
}

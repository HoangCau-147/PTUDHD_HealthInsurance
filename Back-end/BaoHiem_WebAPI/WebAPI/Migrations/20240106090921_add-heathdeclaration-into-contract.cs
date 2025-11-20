using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class addheathdeclarationintocontract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "HealthDeclaration",
                table: "Contracts",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "HealthDeclaration",
                table: "Contracts");

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
    }
}

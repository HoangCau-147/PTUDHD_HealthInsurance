using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20e5e945-5cfe-4c69-871b-a3504a565dcb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e6e4279-b1a0-42ed-b778-dba6578e4464");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "573d566c-bfe9-4b12-b636-2f1cc71d8659");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f13d1acf-9672-4948-b3a7-99c04083fe91");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26444409-e1b9-4408-b51a-40fa2beca7c4", "95f4a2f5-7318-4d0b-a9bb-3ae6aaca90ad", "Customer", "CUSTOMER" },
                    { "9b2d993a-813c-43b8-8ae7-157aa7419dde", "4b479346-1c42-465c-a22c-baaef86a3468", "Administrator", "ADMINISTRATOR" },
                    { "9fd54552-40c0-4c4a-82bd-612e7dcbca34", "dbb49e07-16d2-4c10-9f2f-3c134e4ec4a2", "Manager", "MANAGER" },
                    { "a2af37bc-1c4a-4b8b-bdc9-fd5e1436a4eb", "531d7b9e-9c1e-4fe3-8466-033fe1eeab1f", "Employee", "EMPLOYEE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26444409-e1b9-4408-b51a-40fa2beca7c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b2d993a-813c-43b8-8ae7-157aa7419dde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fd54552-40c0-4c4a-82bd-612e7dcbca34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2af37bc-1c4a-4b8b-bdc9-fd5e1436a4eb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20e5e945-5cfe-4c69-871b-a3504a565dcb", "a87ed19d-4e9f-4930-9037-dd86c3711e89", "Customer", "CUSTOMER" },
                    { "4e6e4279-b1a0-42ed-b778-dba6578e4464", "78fb9714-9423-4e1c-924a-6929b56621a1", "Administrator", "ADMINISTRATOR" },
                    { "573d566c-bfe9-4b12-b636-2f1cc71d8659", "1c840cd0-7e22-4a17-9db0-49da0c35cc65", "Manager", "MANAGER" },
                    { "f13d1acf-9672-4948-b3a7-99c04083fe91", "9281e73d-098a-4367-a8dd-eb2cb778fe57", "Employee", "EMPLOYEE" }
                });
        }
    }
}

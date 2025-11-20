using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01eb3ffa-04f6-4e37-9f5a-fdcd79e6f82c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b2d9cde-3d2a-4601-a650-409382b157f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "986504d9-0671-4b01-9758-ff6f3203e88e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a41c0aa1-fc77-4922-80d6-29c79a0c4fc1");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "01eb3ffa-04f6-4e37-9f5a-fdcd79e6f82c", "cc2917e5-4381-49f0-8691-272334207b3a", "Manager", "MANAGER" },
                    { "7b2d9cde-3d2a-4601-a650-409382b157f2", "b2a958dc-0058-4518-acbb-2d336182e24a", "Administrator", "ADMINISTRATOR" },
                    { "986504d9-0671-4b01-9758-ff6f3203e88e", "e945e9a9-71e2-4000-8d96-51355cea3cad", "Employee", "EMPLOYEE" },
                    { "a41c0aa1-fc77-4922-80d6-29c79a0c4fc1", "baf047d4-7802-43b0-bdf1-6378def3c85a", "Customer", "CUSTOMER" }
                });
        }
    }
}

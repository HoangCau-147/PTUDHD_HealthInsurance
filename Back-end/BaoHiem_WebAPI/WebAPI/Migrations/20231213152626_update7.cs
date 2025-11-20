using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class update7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "194b43f4-7792-468a-9342-79b1ac08ff86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c11718d-52f3-4b42-ab87-44dd4ff36f6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb258e11-e2f6-40d3-88c3-58b49cdd2dd0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c92e7129-d05d-450d-a609-2e4ffed7826e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41f08186-d047-44d6-b3c5-a584c5251ea0", "ea01beb5-e674-4d4e-9f99-08eb941e0807", "Employee", "EMPLOYEE" },
                    { "b7c84f14-2fe2-4d9e-b7a2-1ace422a3286", "faa1394a-b17e-4311-adcf-d513cc12a3b1", "Administrator", "ADMINISTRATOR" },
                    { "c365c196-9bcb-426c-bb9a-d7b2c23775ed", "9bac218e-63f2-4802-b623-a47a11284300", "Manager", "MANAGER" },
                    { "f115240f-f0f2-4ed7-aa6c-3ab6408c38ba", "96bce31e-4d98-45c1-a51c-d73c1a7f9483", "Customer", "CUSTOMER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41f08186-d047-44d6-b3c5-a584c5251ea0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7c84f14-2fe2-4d9e-b7a2-1ace422a3286");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c365c196-9bcb-426c-bb9a-d7b2c23775ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f115240f-f0f2-4ed7-aa6c-3ab6408c38ba");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "194b43f4-7792-468a-9342-79b1ac08ff86", "7626abdc-3a97-435c-957c-1a7d9862f57d", "Employee", "EMPLOYEE" },
                    { "2c11718d-52f3-4b42-ab87-44dd4ff36f6b", "7bde2770-2d35-4542-97f3-a9edcbae9fae", "Customer", "CUSTOMER" },
                    { "bb258e11-e2f6-40d3-88c3-58b49cdd2dd0", "c5739526-2b3e-4ac4-b330-a58d0f870b90", "Administrator", "ADMINISTRATOR" },
                    { "c92e7129-d05d-450d-a609-2e4ffed7826e", "c3c3fcdb-429a-49fd-8e05-d075cd3160bc", "Manager", "MANAGER" }
                });
        }
    }
}

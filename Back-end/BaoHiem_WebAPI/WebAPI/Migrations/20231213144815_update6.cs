using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26445e85-0800-4792-b610-17b8c033df2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e91136e-f7c2-4e15-a81f-852350b43ecb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b96e05ef-b83d-44f6-9c5f-0e1aaa672809");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc4c9f4a-1221-41b0-b41f-5b385eeeea79");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "InsurancePrices",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "InsurancePrices",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26445e85-0800-4792-b610-17b8c033df2d", "706d0dea-b479-4461-a1e8-eeabc8eb61f9", "Administrator", "ADMINISTRATOR" },
                    { "4e91136e-f7c2-4e15-a81f-852350b43ecb", "2729f65f-7eb7-4c2a-ad05-2f287fb428fd", "Employee", "EMPLOYEE" },
                    { "b96e05ef-b83d-44f6-9c5f-0e1aaa672809", "211f5217-7293-41a9-aa1c-75f71c22858b", "Customer", "CUSTOMER" },
                    { "dc4c9f4a-1221-41b0-b41f-5b385eeeea79", "605cc150-a5a3-4100-a586-ca34f376107a", "Manager", "MANAGER" }
                });
        }
    }
}

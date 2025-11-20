using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TotalPrice",
                table: "Contracts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "014ef029-7563-4b6c-b086-f28908560acf", "80ac067f-e25e-4756-9052-494f67bafd06", "Manager", "MANAGER" },
                    { "78e94446-38d1-4978-bc1d-6755fff99aa3", "1de64d64-7823-42cc-9698-61f69c18cdfe", "Employee", "EMPLOYEE" },
                    { "8e701968-173f-46bd-b8a7-1765eee279f6", "bca45306-6c5c-4099-aebb-b7eb4d08ee2b", "Administrator", "ADMINISTRATOR" },
                    { "f336fd8d-4058-4601-809f-91a7f38d2577", "eb70f83a-1643-4f9b-83d2-2c5c1deccf80", "Customer", "CUSTOMER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "014ef029-7563-4b6c-b086-f28908560acf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78e94446-38d1-4978-bc1d-6755fff99aa3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e701968-173f-46bd-b8a7-1765eee279f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f336fd8d-4058-4601-809f-91a7f38d2577");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Contracts");

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
    }
}

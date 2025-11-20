using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updatedatabase11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "133de218-b3b7-4be7-8576-0a033591a872");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67550add-bef6-48af-8801-088e9290959e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f190131-9931-4458-a756-6041166f6120");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edfcd409-884b-4f27-a73d-4f25475785cd");

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "ContractsInvoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29b07df6-bec9-4ff4-b14c-733345d0ad84", "12b1c792-5438-4a4c-baaf-53f26caea3bb", "Employee", "EMPLOYEE" },
                    { "9707ee4c-3108-4929-a021-8ad4df00016d", "04bf5848-cbbf-41ba-8c51-f3423e8902e7", "Customer", "CUSTOMER" },
                    { "c810ce78-0528-4be5-9ce4-8f2c68c14187", "90a28774-1b09-4899-b4e0-1e1c3607d0f4", "Manager", "MANAGER" },
                    { "f50cb04a-044e-4f12-8fb8-972799ede9b1", "278ad664-3ac8-48be-8e70-82ef0e32b3a9", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29b07df6-bec9-4ff4-b14c-733345d0ad84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9707ee4c-3108-4929-a021-8ad4df00016d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c810ce78-0528-4be5-9ce4-8f2c68c14187");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f50cb04a-044e-4f12-8fb8-972799ede9b1");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "ContractsInvoice");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "133de218-b3b7-4be7-8576-0a033591a872", "dcb5c988-58a3-489f-87cb-1b2eb5763319", "Administrator", "ADMINISTRATOR" },
                    { "67550add-bef6-48af-8801-088e9290959e", "2aecaf8d-a985-4869-a5b9-065b11343128", "Manager", "MANAGER" },
                    { "8f190131-9931-4458-a756-6041166f6120", "a6dcef42-94ec-4180-8ffc-a343c227e1f2", "Customer", "CUSTOMER" },
                    { "edfcd409-884b-4f27-a73d-4f25475785cd", "08a91efb-d0b1-4be1-8a9a-d2c81ab8ad86", "Employee", "EMPLOYEE" }
                });
        }
    }
}

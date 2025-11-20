using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updateclaimrequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "TotalCost",
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

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ClaimRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                table: "ClaimPayment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "MedicalCondition",
                table: "ClaimRequests");

            migrationBuilder.DropColumn(
                name: "MedicalHistory",
                table: "ClaimRequests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ClaimRequests");

            migrationBuilder.AddColumn<int>(
                name: "TotalCost",
                table: "ClaimRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethod",
                table: "ClaimPayment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}

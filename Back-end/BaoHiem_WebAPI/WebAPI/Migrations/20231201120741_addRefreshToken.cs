using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class addRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "567316e6-5cd6-463a-95c3-d34c36e9ed5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a1dca93-6f0d-4e4f-8865-9eb4ab898500");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e31b2485-ed37-4bba-bcff-a52884aa7b21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f86dc607-1a23-447a-80d8-9a933bde10dc");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8bdaf635-836c-4374-84d3-0ab2587283fe", "e4264a22-6657-48eb-901f-f76ba80a5353", "Administrator", "ADMINISTRATOR" },
                    { "d2b0cb51-3981-4184-bc25-4f574f1b49c0", "3b950c81-b85a-422b-9f5c-4ef1779f354f", "Customer", "CUSTOMER" },
                    { "dd46d8ba-9e68-4400-880b-37bf88cbcd88", "0e893225-b9e1-4b38-82ff-e928459ea600", "Manager", "MANAGER" },
                    { "dd9d68a0-330d-4999-9dca-2d85997d4b18", "1f947e0d-301d-4d16-a5d2-507db5d83145", "Employee", "EMPLOYEE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bdaf635-836c-4374-84d3-0ab2587283fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2b0cb51-3981-4184-bc25-4f574f1b49c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd46d8ba-9e68-4400-880b-37bf88cbcd88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd9d68a0-330d-4999-9dca-2d85997d4b18");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "567316e6-5cd6-463a-95c3-d34c36e9ed5a", "bdf4e2a4-b530-4aeb-9052-1b572b793974", "Customer", "CUSTOMER" },
                    { "6a1dca93-6f0d-4e4f-8865-9eb4ab898500", "147e5112-c657-4f01-8b5f-6bd94c03adab", "Manager", "MANAGER" },
                    { "e31b2485-ed37-4bba-bcff-a52884aa7b21", "1441f45f-2ad3-49fb-9841-f46da4792186", "Administrator", "ADMINISTRATOR" },
                    { "f86dc607-1a23-447a-80d8-9a933bde10dc", "3cf17ff7-1d70-4acb-95e5-ed98f89cd761", "Employee", "EMPLOYEE" }
                });
        }
    }
}

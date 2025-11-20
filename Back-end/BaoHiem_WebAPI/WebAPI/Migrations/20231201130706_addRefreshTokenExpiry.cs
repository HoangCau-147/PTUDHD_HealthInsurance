using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class addRefreshTokenExpiry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiry",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28857028-8cbe-43e3-ba81-3c7519be0462", "07dbb5b4-edb1-455d-ab2d-8528c9093f4e", "Manager", "MANAGER" },
                    { "478a7d26-77c9-484e-9250-d059e041f85f", "5074a092-e0fd-4838-912c-2543d07e662b", "Administrator", "ADMINISTRATOR" },
                    { "8d77636c-7a1e-4bb2-b1b8-5dccacc9dee4", "55c0251a-9752-465a-9d75-e427f339fad5", "Customer", "CUSTOMER" },
                    { "e150783f-10d4-488c-a59b-1ae0ebca7c05", "b2c0544e-0e32-491f-820b-a05b92d81bf3", "Employee", "EMPLOYEE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28857028-8cbe-43e3-ba81-3c7519be0462");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "478a7d26-77c9-484e-9250-d059e041f85f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d77636c-7a1e-4bb2-b1b8-5dccacc9dee4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e150783f-10d4-488c-a59b-1ae0ebca7c05");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiry",
                table: "AspNetUsers");

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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updateProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09a00797-ea19-4a11-a0d8-9da5ca786cd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bda6f61-35ec-4a79-8bc7-78af43e007de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa317986-5737-4c94-93d9-35e15003f72b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb77def0-5e36-4e9e-99b8-bc1d03370996");

            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "InsurancePrograms",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f6de6ac-5d6d-4e1a-b014-ddfc713e79af", "988568f4-47f5-441c-a673-2a2d36079df0", "Manager", "MANAGER" },
                    { "54b316e2-076d-4dcb-8538-c9c166bcc899", "365f22b0-2dc2-49fb-82cc-0209e06d9b8c", "Customer", "CUSTOMER" },
                    { "d0d91264-fd29-44c4-8ef8-8b8b528ef379", "fa4e2e2c-66c4-4b0e-99e9-6ded54526d30", "Employee", "EMPLOYEE" },
                    { "d6475535-74d8-4c5a-9668-cbbe4ae443e8", "309b427f-5564-44a5-a1d6-332561a685e4", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f6de6ac-5d6d-4e1a-b014-ddfc713e79af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54b316e2-076d-4dcb-8538-c9c166bcc899");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0d91264-fd29-44c4-8ef8-8b8b528ef379");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6475535-74d8-4c5a-9668-cbbe4ae443e8");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "InsurancePrograms");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09a00797-ea19-4a11-a0d8-9da5ca786cd5", "16a665c2-bbb7-4b7a-ae11-e345bc9f863d", "Employee", "EMPLOYEE" },
                    { "3bda6f61-35ec-4a79-8bc7-78af43e007de", "4fea73ec-03e4-4917-b99d-f47377fc2448", "Customer", "CUSTOMER" },
                    { "aa317986-5737-4c94-93d9-35e15003f72b", "55211863-b7b9-484a-8823-43cccee4f1cc", "Administrator", "ADMINISTRATOR" },
                    { "eb77def0-5e36-4e9e-99b8-bc1d03370996", "62108c91-0232-440b-9287-3ecdc2c29a14", "Manager", "MANAGER" }
                });
        }
    }
}

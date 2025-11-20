using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class addForeignKey_HealthConditionInsuranceProduct7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_healthConditionInsuranceProducts_InsuranceProducts_InsuranceProductId",
                table: "healthConditionInsuranceProducts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "277d4b41-526b-4c84-964c-a6c791a7dfb2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6df76355-c399-44d0-ad7d-11387835e198");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c338f64-5784-4c18-8314-fa5fb9ccab31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db7e9a43-86c7-47ca-9518-6c5c99919568");

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

            migrationBuilder.AddForeignKey(
                name: "FK_healthConditionInsuranceProducts_InsuranceProducts_InsuranceProductId",
                table: "healthConditionInsuranceProducts",
                column: "InsuranceProductId",
                principalTable: "InsuranceProducts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_healthConditionInsuranceProducts_InsuranceProducts_InsuranceProductId",
                table: "healthConditionInsuranceProducts");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "277d4b41-526b-4c84-964c-a6c791a7dfb2", "ed7c4582-2c17-4237-b837-a3538b280303", "Administrator", "ADMINISTRATOR" },
                    { "6df76355-c399-44d0-ad7d-11387835e198", "93989789-5383-4f0a-9fe3-dc548c5cf162", "Customer", "CUSTOMER" },
                    { "9c338f64-5784-4c18-8314-fa5fb9ccab31", "a3e30e98-7188-433b-b70b-4bd96c7248dc", "Employee", "EMPLOYEE" },
                    { "db7e9a43-86c7-47ca-9518-6c5c99919568", "1c5f4bb7-0ee3-4ca2-8c2f-5969b2d237e2", "Manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_healthConditionInsuranceProducts_InsuranceProducts_InsuranceProductId",
                table: "healthConditionInsuranceProducts",
                column: "InsuranceProductId",
                principalTable: "InsuranceProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

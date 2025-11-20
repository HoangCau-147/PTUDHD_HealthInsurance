using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updatedatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "060e87cb-d6c5-471e-a3e8-a9f7b353bbe4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9c9fa7d-03ec-4307-876a-6e30bc862f9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e973899b-ebf9-4286-b4cc-371675fa1017");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f92510b3-004d-473a-ab50-24dbbb77731e");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimHealthServices_ClaimRequests_RequestId",
                table: "ClaimHealthServices",
                column: "RequestId",
                principalTable: "ClaimRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimHealthServices_ClaimRequests_RequestId",
                table: "ClaimHealthServices");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "060e87cb-d6c5-471e-a3e8-a9f7b353bbe4", "24541546-5853-4af6-882d-1cc151834eba", "Customer", "CUSTOMER" },
                    { "c9c9fa7d-03ec-4307-876a-6e30bc862f9c", "5609b6f2-c44a-4648-88d1-c08a002597dc", "Manager", "MANAGER" },
                    { "e973899b-ebf9-4286-b4cc-371675fa1017", "e9c98567-9f45-4075-8994-a1f03c6fa65c", "Administrator", "ADMINISTRATOR" },
                    { "f92510b3-004d-473a-ab50-24dbbb77731e", "cd4b9668-7782-4d49-adef-55c0d3c7e4bf", "Employee", "EMPLOYEE" }
                });
        }
    }
}

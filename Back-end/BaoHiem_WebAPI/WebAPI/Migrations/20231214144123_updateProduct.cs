using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updateProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4d07ae8-ba59-42c4-b20a-15a8f0a6b003");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc02e73a-4da1-4495-b8a3-7b1d6496c786");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de111084-c0ad-4bb5-b9ba-da0a3966f65f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff3be2f1-150a-449b-97e9-259eb14764a1");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "InsuranceProducts",
                newName: "TerritorialScope");

            migrationBuilder.AddColumn<string>(
                name: "Commitment",
                table: "InsuranceProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeeGuarantee",
                table: "InsuranceProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuredParty",
                table: "InsuranceProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParticipationProcedure",
                table: "InsuranceProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22a68c4c-2c86-4da5-8bf7-e3a477052b50", "d4a4b636-5946-4f10-85bf-f630e8f2e741", "Customer", "CUSTOMER" },
                    { "2c9dd93b-f767-446c-8698-2c7ed17b23a6", "4fc0734b-ea1c-442e-ab3f-f1a2c919b8ee", "Manager", "MANAGER" },
                    { "97fb4312-3dc7-440c-94b0-29fc23364c92", "bc3d419f-d3a4-46e3-99f3-51271c7065cd", "Employee", "EMPLOYEE" },
                    { "c8f7f1ef-2fbe-4862-8c17-e407bfebbc4f", "877cbc39-0947-46ce-9b36-acc8ac7aa156", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22a68c4c-2c86-4da5-8bf7-e3a477052b50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c9dd93b-f767-446c-8698-2c7ed17b23a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97fb4312-3dc7-440c-94b0-29fc23364c92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8f7f1ef-2fbe-4862-8c17-e407bfebbc4f");

            migrationBuilder.DropColumn(
                name: "Commitment",
                table: "InsuranceProducts");

            migrationBuilder.DropColumn(
                name: "FeeGuarantee",
                table: "InsuranceProducts");

            migrationBuilder.DropColumn(
                name: "InsuredParty",
                table: "InsuranceProducts");

            migrationBuilder.DropColumn(
                name: "ParticipationProcedure",
                table: "InsuranceProducts");

            migrationBuilder.RenameColumn(
                name: "TerritorialScope",
                table: "InsuranceProducts",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d4d07ae8-ba59-42c4-b20a-15a8f0a6b003", "a30f0579-8948-4b90-92a6-812b7e08a04e", "Manager", "MANAGER" },
                    { "dc02e73a-4da1-4495-b8a3-7b1d6496c786", "d4e91589-4b57-4810-85ba-1ab24f536969", "Customer", "CUSTOMER" },
                    { "de111084-c0ad-4bb5-b9ba-da0a3966f65f", "4eb235b4-4b9e-4e62-8b01-62bd580a24f6", "Employee", "EMPLOYEE" },
                    { "ff3be2f1-150a-449b-97e9-259eb14764a1", "8ab5212b-8515-46cd-a5a6-9a6109b6ba0b", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

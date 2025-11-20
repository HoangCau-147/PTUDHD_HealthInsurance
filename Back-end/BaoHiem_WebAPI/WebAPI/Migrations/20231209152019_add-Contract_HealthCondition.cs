using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class addContract_HealthCondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthConditions_Contracts_ContractId",
                table: "HealthConditions");

            migrationBuilder.DropIndex(
                name: "IX_HealthConditions_ContractId",
                table: "HealthConditions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b2117b1-1aed-4e9d-ba39-89224c315774");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4251d156-fc79-4bb3-82af-ffbe6d739ba7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5165b178-81d1-45b4-9295-e73af45a1bf4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82d42ba2-f958-4f9d-9032-cfdb8b4791a2");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "HealthConditions");

            migrationBuilder.DropColumn(
                name: "Static",
                table: "HealthConditions");

            migrationBuilder.CreateTable(
                name: "ContractHealthConditions",
                columns: table => new
                {
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthConditionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractHealthConditions", x => new { x.ContractId, x.HealthConditionId });
                    table.ForeignKey(
                        name: "FK_ContractHealthConditions_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractHealthConditions_HealthConditions_HealthConditionId",
                        column: x => x.HealthConditionId,
                        principalTable: "HealthConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36d7e530-352e-4b79-9e5d-46630ae54410", "4db5cfe7-c5b5-433f-b1b9-8a5dea016a76", "Manager", "MANAGER" },
                    { "e8241dbb-3e80-4145-ac6c-9ef9423d9d3f", "5d83879b-817c-4bd1-8249-5fee6a604c3d", "Customer", "CUSTOMER" },
                    { "ee8499d7-566b-4418-8024-6f15ab04d313", "43210070-388f-407c-802e-1d58487c523e", "Employee", "EMPLOYEE" },
                    { "f7165ebc-0fa7-48d5-8496-c81a0ab2aeff", "defa2bf0-77dc-408c-b593-85fb94504694", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractHealthConditions_HealthConditionId",
                table: "ContractHealthConditions",
                column: "HealthConditionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractHealthConditions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36d7e530-352e-4b79-9e5d-46630ae54410");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8241dbb-3e80-4145-ac6c-9ef9423d9d3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee8499d7-566b-4418-8024-6f15ab04d313");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7165ebc-0fa7-48d5-8496-c81a0ab2aeff");

            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "HealthConditions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Static",
                table: "HealthConditions",
                type: "bit",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b2117b1-1aed-4e9d-ba39-89224c315774", "9273ae51-61f8-4a65-9d6a-c0b71f5d6f5d", "Employee", "EMPLOYEE" },
                    { "4251d156-fc79-4bb3-82af-ffbe6d739ba7", "53338831-fd45-4792-a3d0-c5a898175b8c", "Administrator", "ADMINISTRATOR" },
                    { "5165b178-81d1-45b4-9295-e73af45a1bf4", "fade1046-1a0e-4f6c-a04e-19711ff5252b", "Customer", "CUSTOMER" },
                    { "82d42ba2-f958-4f9d-9032-cfdb8b4791a2", "2a5636e7-e67b-4ac2-8b4a-98a9dea7ea0c", "Manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthConditions_ContractId",
                table: "HealthConditions",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthConditions_Contracts_ContractId",
                table: "HealthConditions",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");
        }
    }
}

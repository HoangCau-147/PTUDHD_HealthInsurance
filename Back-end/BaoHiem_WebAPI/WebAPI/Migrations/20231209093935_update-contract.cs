using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updatecontract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "355af36f-a24c-44cd-ac79-8d7f63c7380d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76aafc0f-d7d9-496f-981d-9d0cd22ca527");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5864191-8065-41ef-8f50-eed8664ed62c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef85cff9-8587-4d58-a92a-c839fbfebf2f");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "InsurancePrograms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DiseaseTypeId",
                table: "InsuranceBenefits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "ContractsInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "HealthConditionType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthConditionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceDiseaseType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiseaseTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceDiseaseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthConditionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Static = table.Column<bool>(type: "bit", nullable: true),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthConditions_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HealthConditions_HealthConditionType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "HealthConditionType",
                        principalColumn: "Id");
                });

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
                name: "IX_InsuranceBenefits_DiseaseTypeId",
                table: "InsuranceBenefits",
                column: "DiseaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthConditions_ContractId",
                table: "HealthConditions",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthConditions_TypeId",
                table: "HealthConditions",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceBenefits_InsuranceDiseaseType_DiseaseTypeId",
                table: "InsuranceBenefits",
                column: "DiseaseTypeId",
                principalTable: "InsuranceDiseaseType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceBenefits_InsuranceDiseaseType_DiseaseTypeId",
                table: "InsuranceBenefits");

            migrationBuilder.DropTable(
                name: "HealthConditions");

            migrationBuilder.DropTable(
                name: "InsuranceDiseaseType");

            migrationBuilder.DropTable(
                name: "HealthConditionType");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceBenefits_DiseaseTypeId",
                table: "InsuranceBenefits");

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
                name: "NormalizedName",
                table: "InsurancePrograms");

            migrationBuilder.DropColumn(
                name: "DiseaseTypeId",
                table: "InsuranceBenefits");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "ContractsInvoice");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Contracts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "355af36f-a24c-44cd-ac79-8d7f63c7380d", "80cc5609-f8fa-427e-84d5-0313b052f0c2", "Employee", "EMPLOYEE" },
                    { "76aafc0f-d7d9-496f-981d-9d0cd22ca527", "7fd9f2f3-0eec-4e9a-a7d4-84e318f21b56", "Administrator", "ADMINISTRATOR" },
                    { "c5864191-8065-41ef-8f50-eed8664ed62c", "2e68fc90-ae43-4a7f-bf0b-89fc3187da22", "Manager", "MANAGER" },
                    { "ef85cff9-8587-4d58-a92a-c839fbfebf2f", "4d71dc1a-a98c-4fd5-9745-eb26c4f1a3d4", "Customer", "CUSTOMER" }
                });
        }
    }
}

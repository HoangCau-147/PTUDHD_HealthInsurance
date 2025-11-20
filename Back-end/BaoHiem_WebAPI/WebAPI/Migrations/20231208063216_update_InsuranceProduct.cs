using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class update_InsuranceProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08021294-e34b-49d0-9a33-03eff2eba24a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ea6c305-3b9b-4426-b75d-1d9bca4ddba5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47c43e95-4b1b-4be0-ba74-0b68aa3fb770");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1f399e2-1f42-4652-a22d-4dca8c11cb2c");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "InsurancePolicies");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "InsurancePolicies");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "InsurancePrograms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "InsurancePolicies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "InsurancePolicies",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "InsurancePolicies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BenefitName",
                table: "InsuranceBenefits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "InsuranceBenefits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cost",
                table: "InsuranceBenefitCosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameBenefit",
                table: "InsuranceBenefitCosts",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Name",
                table: "InsurancePrograms");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "InsurancePolicies");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "InsurancePolicies");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "InsurancePolicies");

            migrationBuilder.DropColumn(
                name: "BenefitName",
                table: "InsuranceBenefits");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "InsuranceBenefits");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "InsuranceBenefitCosts");

            migrationBuilder.DropColumn(
                name: "NameBenefit",
                table: "InsuranceBenefitCosts");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "InsurancePolicies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "InsurancePolicies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08021294-e34b-49d0-9a33-03eff2eba24a", "e54c29b9-e642-4b5a-8265-9546da9b2460", "Administrator", "ADMINISTRATOR" },
                    { "2ea6c305-3b9b-4426-b75d-1d9bca4ddba5", "17addc5c-ad86-4a20-9ef4-13cabac73239", "Employee", "EMPLOYEE" },
                    { "47c43e95-4b1b-4be0-ba74-0b68aa3fb770", "ebaa3c2f-04d3-47ea-bafe-769263b21150", "Customer", "CUSTOMER" },
                    { "e1f399e2-1f42-4652-a22d-4dca8c11cb2c", "4e8a4a3f-afbf-4deb-b4c9-2ba702b3a51f", "Manager", "MANAGER" }
                });
        }
    }
}

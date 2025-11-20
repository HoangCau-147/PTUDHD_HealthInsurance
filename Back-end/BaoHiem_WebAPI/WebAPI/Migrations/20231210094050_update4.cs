using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_InsurancePolicies_InsuranceProductId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceBenefitCosts_InsurancePolicies_ProductId",
                table: "InsuranceBenefitCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceBenefits_InsurancePolicies_ProductId",
                table: "InsuranceBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_InsurancePrices_InsurancePolicies_ProductId",
                table: "InsurancePrices");

            migrationBuilder.DropTable(
                name: "HealthConditionInsuranceProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsurancePolicies",
                table: "InsurancePolicies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26444409-e1b9-4408-b51a-40fa2beca7c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b2d993a-813c-43b8-8ae7-157aa7419dde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fd54552-40c0-4c4a-82bd-612e7dcbca34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2af37bc-1c4a-4b8b-bdc9-fd5e1436a4eb");

            migrationBuilder.RenameTable(
                name: "InsurancePolicies",
                newName: "InsuranceProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsuranceProducts",
                table: "InsuranceProducts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "healthConditionInsuranceProducts",
                columns: table => new
                {
                    HealthConditionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsuranceProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_healthConditionInsuranceProducts", x => new { x.InsuranceProductId, x.HealthConditionId });
                    table.ForeignKey(
                        name: "FK_healthConditionInsuranceProducts_HealthConditions_HealthConditionId",
                        column: x => x.HealthConditionId,
                        principalTable: "HealthConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_healthConditionInsuranceProducts_InsuranceProducts_InsuranceProductId",
                        column: x => x.InsuranceProductId,
                        principalTable: "InsuranceProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a3476b6-0195-4827-b773-cb0c89cb9ad0", "2eb5b69d-82f1-42c4-b2b5-2a201ce8ede1", "Customer", "CUSTOMER" },
                    { "6b0ebeff-ece4-4b02-94ec-46f1f1d94add", "c6271381-89de-44d2-a825-6006af9d811c", "Manager", "MANAGER" },
                    { "a0dec5e6-7900-4ef4-88bb-812535812adb", "657b47e9-fcf9-4228-9143-f0cf58a37712", "Administrator", "ADMINISTRATOR" },
                    { "ed94f2b6-d4e5-423d-ab33-c79af367a63c", "15957f3c-7995-4725-b02e-2b263ea82b1f", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_healthConditionInsuranceProducts_HealthConditionId",
                table: "healthConditionInsuranceProducts",
                column: "HealthConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_InsuranceProducts_InsuranceProductId",
                table: "Contracts",
                column: "InsuranceProductId",
                principalTable: "InsuranceProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceBenefitCosts_InsuranceProducts_ProductId",
                table: "InsuranceBenefitCosts",
                column: "ProductId",
                principalTable: "InsuranceProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceBenefits_InsuranceProducts_ProductId",
                table: "InsuranceBenefits",
                column: "ProductId",
                principalTable: "InsuranceProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsurancePrices_InsuranceProducts_ProductId",
                table: "InsurancePrices",
                column: "ProductId",
                principalTable: "InsuranceProducts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_InsuranceProducts_InsuranceProductId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceBenefitCosts_InsuranceProducts_ProductId",
                table: "InsuranceBenefitCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceBenefits_InsuranceProducts_ProductId",
                table: "InsuranceBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_InsurancePrices_InsuranceProducts_ProductId",
                table: "InsurancePrices");

            migrationBuilder.DropTable(
                name: "healthConditionInsuranceProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsuranceProducts",
                table: "InsuranceProducts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a3476b6-0195-4827-b773-cb0c89cb9ad0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b0ebeff-ece4-4b02-94ec-46f1f1d94add");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0dec5e6-7900-4ef4-88bb-812535812adb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed94f2b6-d4e5-423d-ab33-c79af367a63c");

            migrationBuilder.RenameTable(
                name: "InsuranceProducts",
                newName: "InsurancePolicies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsurancePolicies",
                table: "InsurancePolicies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "HealthConditionInsuranceProduct",
                columns: table => new
                {
                    HealthConditionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthConditionInsuranceProduct", x => new { x.HealthConditionsId, x.productsId });
                    table.ForeignKey(
                        name: "FK_HealthConditionInsuranceProduct_HealthConditions_HealthConditionsId",
                        column: x => x.HealthConditionsId,
                        principalTable: "HealthConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthConditionInsuranceProduct_InsurancePolicies_productsId",
                        column: x => x.productsId,
                        principalTable: "InsurancePolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26444409-e1b9-4408-b51a-40fa2beca7c4", "95f4a2f5-7318-4d0b-a9bb-3ae6aaca90ad", "Customer", "CUSTOMER" },
                    { "9b2d993a-813c-43b8-8ae7-157aa7419dde", "4b479346-1c42-465c-a22c-baaef86a3468", "Administrator", "ADMINISTRATOR" },
                    { "9fd54552-40c0-4c4a-82bd-612e7dcbca34", "dbb49e07-16d2-4c10-9f2f-3c134e4ec4a2", "Manager", "MANAGER" },
                    { "a2af37bc-1c4a-4b8b-bdc9-fd5e1436a4eb", "531d7b9e-9c1e-4fe3-8466-033fe1eeab1f", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthConditionInsuranceProduct_productsId",
                table: "HealthConditionInsuranceProduct",
                column: "productsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_InsurancePolicies_InsuranceProductId",
                table: "Contracts",
                column: "InsuranceProductId",
                principalTable: "InsurancePolicies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceBenefitCosts_InsurancePolicies_ProductId",
                table: "InsuranceBenefitCosts",
                column: "ProductId",
                principalTable: "InsurancePolicies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceBenefits_InsurancePolicies_ProductId",
                table: "InsuranceBenefits",
                column: "ProductId",
                principalTable: "InsurancePolicies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsurancePrices_InsurancePolicies_ProductId",
                table: "InsurancePrices",
                column: "ProductId",
                principalTable: "InsurancePolicies",
                principalColumn: "Id");
        }
    }
}

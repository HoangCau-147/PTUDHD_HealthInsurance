using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceBenefitCosts_InsuranceBenefits_BenefitPolicyId_BenefitId1",
                table: "InsuranceBenefitCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceBenefits_InsuranceProducts_ProductId",
                table: "InsuranceBenefits");

            migrationBuilder.DropTable(
                name: "healthConditionInsuranceProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsuranceBenefits",
                table: "InsuranceBenefits");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceBenefits_ProductId",
                table: "InsuranceBenefits");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceBenefitCosts_BenefitPolicyId_BenefitId1",
                table: "InsuranceBenefitCosts");

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
                name: "PolicyId",
                table: "InsuranceBenefits");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "InsuranceBenefits");

            migrationBuilder.DropColumn(
                name: "BenefitId1",
                table: "InsuranceBenefitCosts");

            migrationBuilder.DropColumn(
                name: "BenefitPolicyId",
                table: "InsuranceBenefitCosts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsuranceBenefits",
                table: "InsuranceBenefits",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "HealthConditionInsuranceProduct",
                columns: table => new
                {
                    HealthConditionSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthConditionInsuranceProduct", x => new { x.HealthConditionSourceId, x.productSourceId });
                    table.ForeignKey(
                        name: "FK_HealthConditionInsuranceProduct_HealthConditions_HealthConditionSourceId",
                        column: x => x.HealthConditionSourceId,
                        principalTable: "HealthConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthConditionInsuranceProduct_InsuranceProducts_productSourceId",
                        column: x => x.productSourceId,
                        principalTable: "InsuranceProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceBenefitInsuranceProduct",
                columns: table => new
                {
                    BenefitsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceBenefitInsuranceProduct", x => new { x.BenefitsId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_InsuranceBenefitInsuranceProduct_InsuranceBenefits_BenefitsId",
                        column: x => x.BenefitsId,
                        principalTable: "InsuranceBenefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceBenefitInsuranceProduct_InsuranceProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "InsuranceProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18accdd6-2852-4881-8d1c-5aa67cb04cbb", "74a2ffd5-93d3-4c81-a746-3e0c6263b480", "Employee", "EMPLOYEE" },
                    { "7941954e-cb7c-4329-ac91-739b0d9c5978", "8d789097-8251-4643-ad0f-068dfa745dbc", "Administrator", "ADMINISTRATOR" },
                    { "881725d9-5180-4ddb-bb64-0ba1e1f68938", "7ea2095f-1bd1-4d98-9299-3e6b1f949cfd", "Manager", "MANAGER" },
                    { "a2d10c25-f63b-4b1d-a06e-2e0ffe5e62a0", "7181bc88-6c19-4c01-8494-42eaf2c5b6a7", "Customer", "CUSTOMER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceBenefitCosts_BenefitId",
                table: "InsuranceBenefitCosts",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthConditionInsuranceProduct_productSourceId",
                table: "HealthConditionInsuranceProduct",
                column: "productSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceBenefitInsuranceProduct_ProductId",
                table: "InsuranceBenefitInsuranceProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceBenefitCosts_InsuranceBenefits_BenefitId",
                table: "InsuranceBenefitCosts",
                column: "BenefitId",
                principalTable: "InsuranceBenefits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceBenefitCosts_InsuranceBenefits_BenefitId",
                table: "InsuranceBenefitCosts");

            migrationBuilder.DropTable(
                name: "HealthConditionInsuranceProduct");

            migrationBuilder.DropTable(
                name: "InsuranceBenefitInsuranceProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsuranceBenefits",
                table: "InsuranceBenefits");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceBenefitCosts_BenefitId",
                table: "InsuranceBenefitCosts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18accdd6-2852-4881-8d1c-5aa67cb04cbb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7941954e-cb7c-4329-ac91-739b0d9c5978");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "881725d9-5180-4ddb-bb64-0ba1e1f68938");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2d10c25-f63b-4b1d-a06e-2e0ffe5e62a0");

            migrationBuilder.AddColumn<Guid>(
                name: "PolicyId",
                table: "InsuranceBenefits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "InsuranceBenefits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BenefitId1",
                table: "InsuranceBenefitCosts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BenefitPolicyId",
                table: "InsuranceBenefitCosts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsuranceBenefits",
                table: "InsuranceBenefits",
                columns: new[] { "PolicyId", "Id" });

            migrationBuilder.CreateTable(
                name: "healthConditionInsuranceProducts",
                columns: table => new
                {
                    InsuranceProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthConditionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_healthConditionInsuranceProducts", x => new { x.InsuranceProductId, x.HealthConditionId });
                    table.ForeignKey(
                        name: "FK_healthConditionInsuranceProducts_HealthConditions_HealthConditionId",
                        column: x => x.HealthConditionId,
                        principalTable: "HealthConditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_healthConditionInsuranceProducts_InsuranceProducts_InsuranceProductId",
                        column: x => x.InsuranceProductId,
                        principalTable: "InsuranceProducts",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceBenefits_ProductId",
                table: "InsuranceBenefits",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceBenefitCosts_BenefitPolicyId_BenefitId1",
                table: "InsuranceBenefitCosts",
                columns: new[] { "BenefitPolicyId", "BenefitId1" });

            migrationBuilder.CreateIndex(
                name: "IX_healthConditionInsuranceProducts_HealthConditionId",
                table: "healthConditionInsuranceProducts",
                column: "HealthConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceBenefitCosts_InsuranceBenefits_BenefitPolicyId_BenefitId1",
                table: "InsuranceBenefitCosts",
                columns: new[] { "BenefitPolicyId", "BenefitId1" },
                principalTable: "InsuranceBenefits",
                principalColumns: new[] { "PolicyId", "Id" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceBenefits_InsuranceProducts_ProductId",
                table: "InsuranceBenefits",
                column: "ProductId",
                principalTable: "InsuranceProducts",
                principalColumn: "Id");
        }
    }
}

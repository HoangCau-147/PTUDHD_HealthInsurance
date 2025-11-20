using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updatedatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceBenefits_InsuranceDiseaseType_DiseaseTypeId",
                table: "InsuranceBenefits");

            migrationBuilder.DropTable(
                name: "InsuranceBenefitInsuranceProduct");

            migrationBuilder.DropTable(
                name: "InsuranceDiseaseType");

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

            migrationBuilder.DropColumn(
                name: "NameBenefit",
                table: "InsuranceBenefitCosts");

            migrationBuilder.RenameColumn(
                name: "DiseaseTypeId",
                table: "InsuranceBenefits",
                newName: "BenefitTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_InsuranceBenefits_DiseaseTypeId",
                table: "InsuranceBenefits",
                newName: "IX_InsuranceBenefits_BenefitTypeId");

            migrationBuilder.AddColumn<float>(
                name: "Multiplier",
                table: "InsurancePrograms",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "BenefitId",
                table: "InsuranceBenefits",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<float>(
                name: "Cost",
                table: "InsuranceBenefitCosts",
                type: "real",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "InsuranceBenefitType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BenefitTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceBenefitType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceBenefitTypeInsuranceProduct",
                columns: table => new
                {
                    BenefitTypesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceBenefitTypeInsuranceProduct", x => new { x.BenefitTypesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_InsuranceBenefitTypeInsuranceProduct_InsuranceBenefitType_BenefitTypesId",
                        column: x => x.BenefitTypesId,
                        principalTable: "InsuranceBenefitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceBenefitTypeInsuranceProduct_InsuranceProducts_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "InsuranceProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5269f5c3-acd4-43fd-a5de-814b61ce30c4", "7d6baf19-cf9c-4d54-bbbe-88d100d63492", "Employee", "EMPLOYEE" },
                    { "67105d22-8251-4361-a82b-be42f19fbbd8", "8c67b1fd-dcc2-4cc0-ae4f-59ca10ce3643", "Customer", "CUSTOMER" },
                    { "8233efd5-21b5-4167-98c2-8e6408724c4d", "b6dbfb11-f0e0-405b-bbd4-85c89cbb228c", "Administrator", "ADMINISTRATOR" },
                    { "a0ea2e4a-6f70-426a-ac19-cfa660b4beb3", "2a593bc2-e8c9-4098-b097-162eefb3727f", "Manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceBenefitTypeInsuranceProduct_ProductsId",
                table: "InsuranceBenefitTypeInsuranceProduct",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceBenefits_InsuranceBenefitType_BenefitTypeId",
                table: "InsuranceBenefits",
                column: "BenefitTypeId",
                principalTable: "InsuranceBenefitType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceBenefits_InsuranceBenefitType_BenefitTypeId",
                table: "InsuranceBenefits");

            migrationBuilder.DropTable(
                name: "InsuranceBenefitTypeInsuranceProduct");

            migrationBuilder.DropTable(
                name: "InsuranceBenefitType");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5269f5c3-acd4-43fd-a5de-814b61ce30c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67105d22-8251-4361-a82b-be42f19fbbd8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8233efd5-21b5-4167-98c2-8e6408724c4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0ea2e4a-6f70-426a-ac19-cfa660b4beb3");

            migrationBuilder.DropColumn(
                name: "Multiplier",
                table: "InsurancePrograms");

            migrationBuilder.DropColumn(
                name: "BenefitId",
                table: "InsuranceBenefits");

            migrationBuilder.RenameColumn(
                name: "BenefitTypeId",
                table: "InsuranceBenefits",
                newName: "DiseaseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_InsuranceBenefits_BenefitTypeId",
                table: "InsuranceBenefits",
                newName: "IX_InsuranceBenefits_DiseaseTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "Cost",
                table: "InsuranceBenefitCosts",
                type: "int",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameBenefit",
                table: "InsuranceBenefitCosts",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "IX_InsuranceBenefitInsuranceProduct_ProductId",
                table: "InsuranceBenefitInsuranceProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceBenefits_InsuranceDiseaseType_DiseaseTypeId",
                table: "InsuranceBenefits",
                column: "DiseaseTypeId",
                principalTable: "InsuranceDiseaseType",
                principalColumn: "Id");
        }
    }
}

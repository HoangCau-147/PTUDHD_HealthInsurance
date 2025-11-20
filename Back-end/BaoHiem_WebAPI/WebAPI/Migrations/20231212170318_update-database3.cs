using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updatedatabase3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthConditionInsuranceProduct");

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

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "HealthConditions",
                newName: "Question");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "HealthConditions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26445e85-0800-4792-b610-17b8c033df2d", "706d0dea-b479-4461-a1e8-eeabc8eb61f9", "Administrator", "ADMINISTRATOR" },
                    { "4e91136e-f7c2-4e15-a81f-852350b43ecb", "2729f65f-7eb7-4c2a-ad05-2f287fb428fd", "Employee", "EMPLOYEE" },
                    { "b96e05ef-b83d-44f6-9c5f-0e1aaa672809", "211f5217-7293-41a9-aa1c-75f71c22858b", "Customer", "CUSTOMER" },
                    { "dc4c9f4a-1221-41b0-b41f-5b385eeeea79", "605cc150-a5a3-4100-a586-ca34f376107a", "Manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthConditions_ProductId",
                table: "HealthConditions",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthConditions_InsuranceProducts_ProductId",
                table: "HealthConditions",
                column: "ProductId",
                principalTable: "InsuranceProducts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthConditions_InsuranceProducts_ProductId",
                table: "HealthConditions");

            migrationBuilder.DropIndex(
                name: "IX_HealthConditions_ProductId",
                table: "HealthConditions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26445e85-0800-4792-b610-17b8c033df2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e91136e-f7c2-4e15-a81f-852350b43ecb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b96e05ef-b83d-44f6-9c5f-0e1aaa672809");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc4c9f4a-1221-41b0-b41f-5b385eeeea79");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "HealthConditions");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "HealthConditions",
                newName: "Type");

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
                name: "IX_HealthConditionInsuranceProduct_productSourceId",
                table: "HealthConditionInsuranceProduct",
                column: "productSourceId");
        }
    }
}

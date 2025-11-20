using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthConditions_HealthConditionType_TypeId",
                table: "HealthConditions");

            migrationBuilder.DropTable(
                name: "HealthConditionType");

            migrationBuilder.DropIndex(
                name: "IX_HealthConditions_TypeId",
                table: "HealthConditions");

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

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "HealthConditions");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "HealthConditions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Contracts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Contracts",
                type: "datetime2",
                nullable: true);

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
                    { "01eb3ffa-04f6-4e37-9f5a-fdcd79e6f82c", "cc2917e5-4381-49f0-8691-272334207b3a", "Manager", "MANAGER" },
                    { "7b2d9cde-3d2a-4601-a650-409382b157f2", "b2a958dc-0058-4518-acbb-2d336182e24a", "Administrator", "ADMINISTRATOR" },
                    { "986504d9-0671-4b01-9758-ff6f3203e88e", "e945e9a9-71e2-4000-8d96-51355cea3cad", "Employee", "EMPLOYEE" },
                    { "a41c0aa1-fc77-4922-80d6-29c79a0c4fc1", "baf047d4-7802-43b0-bdf1-6378def3c85a", "Customer", "CUSTOMER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthConditionInsuranceProduct_productsId",
                table: "HealthConditionInsuranceProduct",
                column: "productsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthConditionInsuranceProduct");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01eb3ffa-04f6-4e37-9f5a-fdcd79e6f82c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b2d9cde-3d2a-4601-a650-409382b157f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "986504d9-0671-4b01-9758-ff6f3203e88e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a41c0aa1-fc77-4922-80d6-29c79a0c4fc1");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "HealthConditions");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Contracts");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "HealthConditions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HealthConditionType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthConditionType", x => x.Id);
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
                name: "IX_HealthConditions_TypeId",
                table: "HealthConditions",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthConditions_HealthConditionType_TypeId",
                table: "HealthConditions",
                column: "TypeId",
                principalTable: "HealthConditionType",
                principalColumn: "Id");
        }
    }
}

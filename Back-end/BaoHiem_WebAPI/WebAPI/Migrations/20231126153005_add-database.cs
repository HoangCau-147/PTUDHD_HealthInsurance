using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class adddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3866100e-3ece-4eb9-b777-7b6d3f8ca777");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a15772c-3f8c-4587-8b38-a9d70cc819b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c23ac149-cdcf-49e0-8c8c-5764c87fa1d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee502b2a-9fd6-431c-8b22-be440b8cc566");

            migrationBuilder.AlterColumn<string>(
                name: "PolicyName",
                table: "InsurancePolicies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateTable(
                name: "ClaimHealthServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostOfATreatment = table.Column<int>(type: "int", nullable: true),
                    HospitalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityTreatment = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimHealthServices", x => new { x.RequestId, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "ClaimRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InsuranceBenefits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceBenefits", x => new { x.PolicyId, x.Id });
                    table.ForeignKey(
                        name: "FK_InsuranceBenefits_InsurancePolicies_ProductId",
                        column: x => x.ProductId,
                        principalTable: "InsurancePolicies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InsurancePrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClaimPayment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    paymentMethod = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<int>(type: "int", nullable: false),
                    RequestID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimPayment_ClaimRequests_RequestID",
                        column: x => x.RequestID,
                        principalTable: "ClaimRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceBenefitCosts",
                columns: table => new
                {
                    BenefitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BenefitPolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BenefitId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceBenefitCosts", x => new { x.PolicyId, x.BenefitId, x.ProgramId });
                    table.ForeignKey(
                        name: "FK_InsuranceBenefitCosts_InsuranceBenefits_BenefitPolicyId_BenefitId1",
                        columns: x => new { x.BenefitPolicyId, x.BenefitId1 },
                        principalTable: "InsuranceBenefits",
                        principalColumns: new[] { "PolicyId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceBenefitCosts_InsurancePolicies_ProductId",
                        column: x => x.ProductId,
                        principalTable: "InsurancePolicies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InsuranceBenefitCosts_InsurancePrograms_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "InsurancePrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsurancePrices",
                columns: table => new
                {
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePrices", x => new { x.PolicyId, x.ProgramId });
                    table.ForeignKey(
                        name: "FK_InsurancePrices_InsurancePolicies_ProductId",
                        column: x => x.ProductId,
                        principalTable: "InsurancePolicies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InsurancePrices_InsurancePrograms_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "InsurancePrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimInvoice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalCost = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimInvoice_ClaimPayment_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "ClaimPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "371e214f-3033-4754-b39b-3d51122a39b2", "cf1dd2e0-893f-4acf-8e22-98143936b12b", "Customer", "CUSTOMER" },
                    { "a1b4f020-f7e9-4e23-88ec-50073314b815", "ede17dec-2207-4b35-922e-10c61246988a", "Manager", "MANAGER" },
                    { "b5f353b6-ba5a-4b28-be44-a5d838346d5f", "bd8be4ed-2a6c-4d2f-b802-6ab273b57438", "Administrator", "ADMINISTRATOR" },
                    { "de1d9cca-2eb5-4039-8786-de67fff74646", "6bfa4a63-0bbb-4853-a8e4-ebe6f22759e1", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimInvoice_PaymentID",
                table: "ClaimInvoice",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimPayment_RequestID",
                table: "ClaimPayment",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserID",
                table: "Customers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserID",
                table: "Employees",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceBenefitCosts_BenefitPolicyId_BenefitId1",
                table: "InsuranceBenefitCosts",
                columns: new[] { "BenefitPolicyId", "BenefitId1" });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceBenefitCosts_ProductId",
                table: "InsuranceBenefitCosts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceBenefitCosts_ProgramId",
                table: "InsuranceBenefitCosts",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceBenefits_ProductId",
                table: "InsuranceBenefits",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePrices_ProductId",
                table: "InsurancePrices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePrices_ProgramId",
                table: "InsurancePrices",
                column: "ProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimHealthServices");

            migrationBuilder.DropTable(
                name: "ClaimInvoice");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "InsuranceBenefitCosts");

            migrationBuilder.DropTable(
                name: "InsurancePrices");

            migrationBuilder.DropTable(
                name: "ClaimPayment");

            migrationBuilder.DropTable(
                name: "InsuranceBenefits");

            migrationBuilder.DropTable(
                name: "InsurancePrograms");

            migrationBuilder.DropTable(
                name: "ClaimRequests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "371e214f-3033-4754-b39b-3d51122a39b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1b4f020-f7e9-4e23-88ec-50073314b815");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5f353b6-ba5a-4b28-be44-a5d838346d5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de1d9cca-2eb5-4039-8786-de67fff74646");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "InsurancePolicies");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "InsurancePolicies");

            migrationBuilder.AlterColumn<string>(
                name: "PolicyName",
                table: "InsurancePolicies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3866100e-3ece-4eb9-b777-7b6d3f8ca777", "5aad6dfd-f861-4e36-81fe-9a83d61fff07", "Administrator", "ADMINISTRATOR" },
                    { "9a15772c-3f8c-4587-8b38-a9d70cc819b6", "5aac5a7d-b123-4927-b120-5465e9fa272f", "Manager", "MANAGER" },
                    { "c23ac149-cdcf-49e0-8c8c-5764c87fa1d7", "43a626a5-fec8-49ba-98ca-1bb291595470", "Employee", "EMPLOYEE" },
                    { "ee502b2a-9fd6-431c-8b22-be440b8cc566", "c4e39593-03da-425b-b487-b3018f26c1a5", "Customer", "CUSTOMER" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ClaimRequests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "ClaimRequests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "ClaimRequests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeID",
                table: "ClaimRequests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "ClaimPayment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsuranceProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsuranceProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_InsurancePolicies_InsuranceProductId",
                        column: x => x.InsuranceProductId,
                        principalTable: "InsurancePolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_InsurancePrograms_InsuranceProgramId",
                        column: x => x.InsuranceProgramId,
                        principalTable: "InsurancePrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractsInvoice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastPrice = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractsInvoice", x => new { x.Id, x.ContractID });
                    table.ForeignKey(
                        name: "FK_ContractsInvoice_Contracts_ContractID",
                        column: x => x.ContractID,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "060e87cb-d6c5-471e-a3e8-a9f7b353bbe4", "24541546-5853-4af6-882d-1cc151834eba", "Customer", "CUSTOMER" },
                    { "c9c9fa7d-03ec-4307-876a-6e30bc862f9c", "5609b6f2-c44a-4648-88d1-c08a002597dc", "Manager", "MANAGER" },
                    { "e973899b-ebf9-4286-b4cc-371675fa1017", "e9c98567-9f45-4075-8994-a1f03c6fa65c", "Administrator", "ADMINISTRATOR" },
                    { "f92510b3-004d-473a-ab50-24dbbb77731e", "cd4b9668-7782-4d49-adef-55c0d3c7e4bf", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimRequests_ContractId",
                table: "ClaimRequests",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimRequests_CustomerId",
                table: "ClaimRequests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimRequests_EmployeeID",
                table: "ClaimRequests",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimPayment_CustomerId",
                table: "ClaimPayment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CustomerID",
                table: "Contracts",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EmployeeID",
                table: "Contracts",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_InsuranceProductId",
                table: "Contracts",
                column: "InsuranceProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_InsuranceProgramId",
                table: "Contracts",
                column: "InsuranceProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractsInvoice_ContractID",
                table: "ContractsInvoice",
                column: "ContractID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimPayment_Customers_CustomerId",
                table: "ClaimPayment",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimRequests_Contracts_ContractId",
                table: "ClaimRequests",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimRequests_Customers_CustomerId",
                table: "ClaimRequests",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimRequests_Employees_EmployeeID",
                table: "ClaimRequests",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimPayment_Customers_CustomerId",
                table: "ClaimPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimRequests_Contracts_ContractId",
                table: "ClaimRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimRequests_Customers_CustomerId",
                table: "ClaimRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimRequests_Employees_EmployeeID",
                table: "ClaimRequests");

            migrationBuilder.DropTable(
                name: "ContractsInvoice");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_ClaimRequests_ContractId",
                table: "ClaimRequests");

            migrationBuilder.DropIndex(
                name: "IX_ClaimRequests_CustomerId",
                table: "ClaimRequests");

            migrationBuilder.DropIndex(
                name: "IX_ClaimRequests_EmployeeID",
                table: "ClaimRequests");

            migrationBuilder.DropIndex(
                name: "IX_ClaimPayment_CustomerId",
                table: "ClaimPayment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "060e87cb-d6c5-471e-a3e8-a9f7b353bbe4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9c9fa7d-03ec-4307-876a-6e30bc862f9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e973899b-ebf9-4286-b4cc-371675fa1017");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f92510b3-004d-473a-ab50-24dbbb77731e");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "ClaimRequests");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ClaimRequests");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "ClaimRequests");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ClaimPayment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ClaimRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class updateclaim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimHealthServices_ClaimRequests_RequestId",
                table: "ClaimHealthServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimPayment_ClaimRequests_RequestID",
                table: "ClaimPayment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56e08eb9-054d-40f9-aa65-4a8de9378f20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f26b3f7-e26d-49e1-b739-6663edb23841");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ff3774-8914-43e5-a36d-1f7417a3e810");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95a5d769-2ff8-4bee-a0d2-85bd779a5737");

            migrationBuilder.DropColumn(
                name: "QuantityTreatment",
                table: "ClaimHealthServices");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ClaimHealthServices");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "ClaimHealthServices",
                newName: "ClaimPaymentId");

            migrationBuilder.AlterColumn<int>(
                name: "TotalCost",
                table: "ClaimPayment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "RequestID",
                table: "ClaimPayment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ClaimPayment",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ClaimPayment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UsedDate",
                table: "ClaimHealthServices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16b23a39-b361-48a0-9666-96d020d5b874", "b2f6654f-e84a-44b2-8f24-28f03d1a954d", "Employee", "EMPLOYEE" },
                    { "6b772407-5ac8-42e4-8f99-341731256fce", "47475842-8486-47b6-aa76-44507bd17a77", "Manager", "MANAGER" },
                    { "91027f26-5178-4904-aa11-c8bc9c211c41", "d20f86d3-db0a-4900-8478-0e4ec2630a09", "Administrator", "ADMINISTRATOR" },
                    { "9662f35a-168a-4cbf-b63d-a5688cbfa0ad", "7803fcbb-88f1-42ba-8cb3-70ceb44df858", "Customer", "CUSTOMER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimHealthServices_ClaimPayment_ClaimPaymentId",
                table: "ClaimHealthServices",
                column: "ClaimPaymentId",
                principalTable: "ClaimPayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimPayment_ClaimRequests_RequestID",
                table: "ClaimPayment",
                column: "RequestID",
                principalTable: "ClaimRequests",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimHealthServices_ClaimPayment_ClaimPaymentId",
                table: "ClaimHealthServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimPayment_ClaimRequests_RequestID",
                table: "ClaimPayment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16b23a39-b361-48a0-9666-96d020d5b874");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b772407-5ac8-42e4-8f99-341731256fce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91027f26-5178-4904-aa11-c8bc9c211c41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9662f35a-168a-4cbf-b63d-a5688cbfa0ad");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ClaimPayment");

            migrationBuilder.DropColumn(
                name: "UsedDate",
                table: "ClaimHealthServices");

            migrationBuilder.RenameColumn(
                name: "ClaimPaymentId",
                table: "ClaimHealthServices",
                newName: "RequestId");

            migrationBuilder.AlterColumn<int>(
                name: "TotalCost",
                table: "ClaimPayment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RequestID",
                table: "ClaimPayment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ClaimPayment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantityTreatment",
                table: "ClaimHealthServices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ClaimHealthServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "56e08eb9-054d-40f9-aa65-4a8de9378f20", "835a6ee0-e7ea-489e-b095-84a5455424e9", "Manager", "MANAGER" },
                    { "5f26b3f7-e26d-49e1-b739-6663edb23841", "5c58e72c-96f2-4201-897a-b263e0ce44b3", "Customer", "CUSTOMER" },
                    { "88ff3774-8914-43e5-a36d-1f7417a3e810", "5eb05ac0-ef8f-40c3-a03d-7515ac72eedd", "Administrator", "ADMINISTRATOR" },
                    { "95a5d769-2ff8-4bee-a0d2-85bd779a5737", "96ac48bf-0615-402a-bd57-fa702a4112e9", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimHealthServices_ClaimRequests_RequestId",
                table: "ClaimHealthServices",
                column: "RequestId",
                principalTable: "ClaimRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimPayment_ClaimRequests_RequestID",
                table: "ClaimPayment",
                column: "RequestID",
                principalTable: "ClaimRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HookahNet.Migrations
{
    public partial class addNullableOrgId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_catalogTable_organizationTable_OrganizationId",
                table: "catalogTable");

            migrationBuilder.DropIndex(
                name: "IX_catalogTable_OrganizationId",
                table: "catalogTable");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganizationId",
                table: "catalogTable",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_catalogTable_OrganizationId",
                table: "catalogTable",
                column: "OrganizationId",
                unique: true,
                filter: "[OrganizationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_catalogTable_organizationTable_OrganizationId",
                table: "catalogTable",
                column: "OrganizationId",
                principalTable: "organizationTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_catalogTable_organizationTable_OrganizationId",
                table: "catalogTable");

            migrationBuilder.DropIndex(
                name: "IX_catalogTable_OrganizationId",
                table: "catalogTable");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganizationId",
                table: "catalogTable",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_catalogTable_OrganizationId",
                table: "catalogTable",
                column: "OrganizationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_catalogTable_organizationTable_OrganizationId",
                table: "catalogTable",
                column: "OrganizationId",
                principalTable: "organizationTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HookahNet.Migrations
{
    public partial class AddedCatalogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "catalogTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_catalogTable_organizationTable_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizationTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_catalogTable_OrganizationId",
                table: "catalogTable",
                column: "OrganizationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "catalogTable");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HookahNet.Migrations
{
    public partial class @fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organizationTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SKU = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizationTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CatalogId = table.Column<Guid>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    HookahProductId = table.Column<Guid>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productTable_productTable_HookahProductId",
                        column: x => x.HookahProductId,
                        principalTable: "productTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Price_productTable_ProductId",
                        column: x => x.ProductId,
                        principalTable: "productTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_catalogTable_OrganizationId",
                table: "catalogTable",
                column: "OrganizationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Price_ProductId",
                table: "Price",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productTable_HookahProductId",
                table: "productTable",
                column: "HookahProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "catalogTable");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "organizationTable");

            migrationBuilder.DropTable(
                name: "productTable");
        }
    }
}

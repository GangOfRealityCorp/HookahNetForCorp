using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HookahNet.Migrations
{
    public partial class changePriceToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Price_totalId",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_Price_SubtotalId",
                table: "ShoppingCartItem");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItem_SubtotalId",
                table: "ShoppingCartItem");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_totalId",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "SubtotalId",
                table: "ShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "totalId",
                table: "ShoppingCart");

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "ShoppingCartItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "ShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "ShoppingCart");

            migrationBuilder.AddColumn<Guid>(
                name: "SubtotalId",
                table: "ShoppingCartItem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "totalId",
                table: "ShoppingCart",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_SubtotalId",
                table: "ShoppingCartItem",
                column: "SubtotalId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_totalId",
                table: "ShoppingCart",
                column: "totalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Price_totalId",
                table: "ShoppingCart",
                column: "totalId",
                principalTable: "Price",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_Price_SubtotalId",
                table: "ShoppingCartItem",
                column: "SubtotalId",
                principalTable: "Price",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

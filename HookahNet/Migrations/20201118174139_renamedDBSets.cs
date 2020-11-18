using Microsoft.EntityFrameworkCore.Migrations;

namespace HookahNet.Migrations
{
    public partial class renamedDBSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Price_productTable_ProductId",
                table: "Price");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_productTable_ProductId",
                table: "ShoppingCartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCartMappingTable_ShoppingCart_ShoppingCartId",
                table: "shoppingCartMappingTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartItem",
                table: "ShoppingCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Price",
                table: "Price");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItem",
                newName: "shoppingCartItemTable");

            migrationBuilder.RenameTable(
                name: "ShoppingCart",
                newName: "shoppingCartTable");

            migrationBuilder.RenameTable(
                name: "Price",
                newName: "priceTable");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItem_ShoppingCartId",
                table: "shoppingCartItemTable",
                newName: "IX_shoppingCartItemTable_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItem_ProductId",
                table: "shoppingCartItemTable",
                newName: "IX_shoppingCartItemTable_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Price_ProductId",
                table: "priceTable",
                newName: "IX_priceTable_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shoppingCartItemTable",
                table: "shoppingCartItemTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shoppingCartTable",
                table: "shoppingCartTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_priceTable",
                table: "priceTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_priceTable_productTable_ProductId",
                table: "priceTable",
                column: "ProductId",
                principalTable: "productTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCartItemTable_productTable_ProductId",
                table: "shoppingCartItemTable",
                column: "ProductId",
                principalTable: "productTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCartItemTable_shoppingCartTable_ShoppingCartId",
                table: "shoppingCartItemTable",
                column: "ShoppingCartId",
                principalTable: "shoppingCartTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCartMappingTable_shoppingCartTable_ShoppingCartId",
                table: "shoppingCartMappingTable",
                column: "ShoppingCartId",
                principalTable: "shoppingCartTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_priceTable_productTable_ProductId",
                table: "priceTable");

            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCartItemTable_productTable_ProductId",
                table: "shoppingCartItemTable");

            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCartItemTable_shoppingCartTable_ShoppingCartId",
                table: "shoppingCartItemTable");

            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCartMappingTable_shoppingCartTable_ShoppingCartId",
                table: "shoppingCartMappingTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shoppingCartTable",
                table: "shoppingCartTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shoppingCartItemTable",
                table: "shoppingCartItemTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_priceTable",
                table: "priceTable");

            migrationBuilder.RenameTable(
                name: "shoppingCartTable",
                newName: "ShoppingCart");

            migrationBuilder.RenameTable(
                name: "shoppingCartItemTable",
                newName: "ShoppingCartItem");

            migrationBuilder.RenameTable(
                name: "priceTable",
                newName: "Price");

            migrationBuilder.RenameIndex(
                name: "IX_shoppingCartItemTable_ShoppingCartId",
                table: "ShoppingCartItem",
                newName: "IX_ShoppingCartItem_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_shoppingCartItemTable_ProductId",
                table: "ShoppingCartItem",
                newName: "IX_ShoppingCartItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_priceTable_ProductId",
                table: "Price",
                newName: "IX_Price_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartItem",
                table: "ShoppingCartItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Price",
                table: "Price",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Price_productTable_ProductId",
                table: "Price",
                column: "ProductId",
                principalTable: "productTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_productTable_ProductId",
                table: "ShoppingCartItem",
                column: "ProductId",
                principalTable: "productTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartItem",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCartMappingTable_ShoppingCart_ShoppingCartId",
                table: "shoppingCartMappingTable",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

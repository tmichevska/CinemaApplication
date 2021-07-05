using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.Web.Data.Migrations
{
    public partial class changedUserClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInShoppingCart_ShoppingCarts_CartId",
                table: "ProductInShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInShoppingCart_Products_ProductId",
                table: "ProductInShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInShoppingCart",
                table: "ProductInShoppingCart");

            migrationBuilder.RenameTable(
                name: "ProductInShoppingCart",
                newName: "ProductsInShoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInShoppingCart_ProductId",
                table: "ProductsInShoppingCarts",
                newName: "IX_ProductsInShoppingCarts_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserShoppingCartCartId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsInShoppingCarts",
                table: "ProductsInShoppingCarts",
                columns: new[] { "CartId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserShoppingCartCartId",
                table: "AspNetUsers",
                column: "UserShoppingCartCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShoppingCarts_UserShoppingCartCartId",
                table: "AspNetUsers",
                column: "UserShoppingCartCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInShoppingCarts_ShoppingCarts_CartId",
                table: "ProductsInShoppingCarts",
                column: "CartId",
                principalTable: "ShoppingCarts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInShoppingCarts_Products_ProductId",
                table: "ProductsInShoppingCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShoppingCarts_UserShoppingCartCartId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInShoppingCarts_ShoppingCarts_CartId",
                table: "ProductsInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInShoppingCarts_Products_ProductId",
                table: "ProductsInShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserShoppingCartCartId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsInShoppingCarts",
                table: "ProductsInShoppingCarts");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserShoppingCartCartId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "ProductsInShoppingCarts",
                newName: "ProductInShoppingCart");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInShoppingCarts_ProductId",
                table: "ProductInShoppingCart",
                newName: "IX_ProductInShoppingCart_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInShoppingCart",
                table: "ProductInShoppingCart",
                columns: new[] { "CartId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInShoppingCart_ShoppingCarts_CartId",
                table: "ProductInShoppingCart",
                column: "CartId",
                principalTable: "ShoppingCarts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInShoppingCart_Products_ProductId",
                table: "ProductInShoppingCart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

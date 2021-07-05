using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.Web.Data.Migrations
{
    public partial class changedShoppingCartProductsRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Products",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Products",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateTable(
                name: "ProductInShoppingCart",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    CartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInShoppingCart", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductInShoppingCart_ShoppingCarts_CartId",
                        column: x => x.CartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInShoppingCart_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInShoppingCart_ProductId",
                table: "ProductInShoppingCart",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }
    }
}

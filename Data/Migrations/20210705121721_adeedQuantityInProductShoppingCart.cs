using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.Web.Data.Migrations
{
    public partial class adeedQuantityInProductShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProductsInShoppingCarts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductsInShoppingCarts");
        }
    }
}

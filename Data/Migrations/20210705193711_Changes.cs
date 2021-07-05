using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.Web.Data.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_OrderById",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInOrder_Order_OrderId",
                table: "ProductInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInOrder_Products_ProductId",
                table: "ProductInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInOrder",
                table: "ProductInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrderById",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderById",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "ProductInOrder",
                newName: "ProductsInOrder");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInOrder_ProductId",
                table: "ProductsInOrder",
                newName: "IX_ProductsInOrder_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "OrderedById",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsInOrder",
                table: "ProductsInOrder",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderedById",
                table: "Orders",
                column: "OrderedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_OrderedById",
                table: "Orders",
                column: "OrderedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInOrder_Orders_OrderId",
                table: "ProductsInOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInOrder_Products_ProductId",
                table: "ProductsInOrder",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_OrderedById",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInOrder_Orders_OrderId",
                table: "ProductsInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInOrder_Products_ProductId",
                table: "ProductsInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsInOrder",
                table: "ProductsInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderedById",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "ProductsInOrder",
                newName: "ProductInOrder");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInOrder_ProductId",
                table: "ProductInOrder",
                newName: "IX_ProductInOrder_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "OrderById",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInOrder",
                table: "ProductInOrder",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderById",
                table: "Order",
                column: "OrderById");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_OrderById",
                table: "Order",
                column: "OrderById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInOrder_Order_OrderId",
                table: "ProductInOrder",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInOrder_Products_ProductId",
                table: "ProductInOrder",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

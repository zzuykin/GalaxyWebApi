using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galaxy.Storage.Migrations
{
    /// <inheritdoc />
    public partial class CartToProductInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carts_CartIsnNode",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CartIsnNode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CartIsnNode",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "CartToProduct",
                columns: table => new
                {
                    CartIsnNode = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductsIsnNode = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartToProduct", x => new { x.CartIsnNode, x.ProductsIsnNode });
                    table.ForeignKey(
                        name: "FK_CartToProduct_Carts_CartIsnNode",
                        column: x => x.CartIsnNode,
                        principalTable: "Carts",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartToProduct_Products_ProductsIsnNode",
                        column: x => x.ProductsIsnNode,
                        principalTable: "Products",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartToProduct_ProductsIsnNode",
                table: "CartToProduct",
                column: "ProductsIsnNode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartToProduct");

            migrationBuilder.AddColumn<Guid>(
                name: "CartIsnNode",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CartIsnNode",
                table: "Products",
                column: "CartIsnNode");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Carts_CartIsnNode",
                table: "Products",
                column: "CartIsnNode",
                principalTable: "Carts",
                principalColumn: "IsnNode");
        }
    }
}

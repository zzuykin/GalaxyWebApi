using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galaxy.Storage.Migrations
{
    /// <inheritdoc />
    public partial class CartInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CartIsnNode",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.IsnNode);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carts_CartIsnNode",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Products_CartIsnNode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CartIsnNode",
                table: "Products");
        }
    }
}

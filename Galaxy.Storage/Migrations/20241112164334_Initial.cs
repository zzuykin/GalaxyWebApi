using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galaxy.Storage.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ClientEmail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    feedBackText = table.Column<string>(type: "text", nullable: false),
                    forPublic = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.IsnNode);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ClientSurname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ClientEmail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ClientPassword = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IsnNode);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnUser = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IsnNode);
                    table.ForeignKey(
                        name: "FK_Orders_Users_IsnUser",
                        column: x => x.IsnUser,
                        principalTable: "Users",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IsnUser",
                table: "Orders",
                column: "IsnUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

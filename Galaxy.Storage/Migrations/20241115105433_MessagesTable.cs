using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galaxy.Storage.Migrations
{
    /// <inheritdoc />
    public partial class MessagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ClientEmail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    MessageSubj = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MessageText = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.IsnNode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}

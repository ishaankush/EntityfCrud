using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entityf.Migrations
{
    /// <inheritdoc />
    public partial class adminuseradded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Music",
                table: "Music");

            migrationBuilder.RenameTable(
                name: "Music",
                newName: "MusicModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicModel",
                table: "MusicModel",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicModel",
                table: "MusicModel");

            migrationBuilder.RenameTable(
                name: "MusicModel",
                newName: "Music");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Music",
                table: "Music",
                column: "Id");
        }
    }
}

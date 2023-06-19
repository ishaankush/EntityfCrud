using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entityf.Migrations
{
    /// <inheritdoc />
    public partial class usernameadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Password");
        }
    }
}

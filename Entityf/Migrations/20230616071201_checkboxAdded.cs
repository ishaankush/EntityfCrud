using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entityf.Migrations
{
    /// <inheritdoc />
    public partial class checkboxAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MyCheckbox",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyCheckbox",
                table: "Users");
        }
    }
}

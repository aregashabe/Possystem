using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSsystem.Migrations
{
    /// <inheritdoc />
    public partial class updateUserEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userRole",
                table: "Users",
                newName: "UserRole");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserRole",
                table: "Users",
                newName: "userRole");
        }
    }
}

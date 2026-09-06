using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSsystem.Migrations
{
    /// <inheritdoc />
    public partial class FixFoodmenuCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foodmenus_Categories_CategoryId",
                table: "Foodmenus");

            migrationBuilder.DropIndex(
                name: "IX_Foodmenus_CategoryId",
                table: "Foodmenus");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Foodmenus");

            migrationBuilder.CreateIndex(
                name: "IX_Foodmenus_CatagoryId",
                table: "Foodmenus",
                column: "CatagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foodmenus_Categories_CatagoryId",
                table: "Foodmenus",
                column: "CatagoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foodmenus_Categories_CatagoryId",
                table: "Foodmenus");

            migrationBuilder.DropIndex(
                name: "IX_Foodmenus_CatagoryId",
                table: "Foodmenus");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Foodmenus",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Foodmenus_CategoryId",
                table: "Foodmenus",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foodmenus_Categories_CategoryId",
                table: "Foodmenus",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

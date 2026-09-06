using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSsystem.Migrations
{
    /// <inheritdoc />
    public partial class AddIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Categories_CategoryId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Foodmenus_FoodmenuId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_IngredientUnits_IngredientUnitId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItem_Ingredient_IngredientId",
                table: "PurchaseItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.RenameTable(
                name: "Ingredient",
                newName: "Ingredients");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_IngredientUnitId",
                table: "Ingredients",
                newName: "IX_Ingredients_IngredientUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_FoodmenuId",
                table: "Ingredients",
                newName: "IX_Ingredients_FoodmenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_CategoryId",
                table: "Ingredients",
                newName: "IX_Ingredients_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Categories_CategoryId",
                table: "Ingredients",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Foodmenus_FoodmenuId",
                table: "Ingredients",
                column: "FoodmenuId",
                principalTable: "Foodmenus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientUnits_IngredientUnitId",
                table: "Ingredients",
                column: "IngredientUnitId",
                principalTable: "IngredientUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItem_Ingredients_IngredientId",
                table: "PurchaseItem",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Categories_CategoryId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Foodmenus_FoodmenuId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientUnits_IngredientUnitId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItem_Ingredients_IngredientId",
                table: "PurchaseItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "Ingredient");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_IngredientUnitId",
                table: "Ingredient",
                newName: "IX_Ingredient_IngredientUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_FoodmenuId",
                table: "Ingredient",
                newName: "IX_Ingredient_FoodmenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_CategoryId",
                table: "Ingredient",
                newName: "IX_Ingredient_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Categories_CategoryId",
                table: "Ingredient",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Foodmenus_FoodmenuId",
                table: "Ingredient",
                column: "FoodmenuId",
                principalTable: "Foodmenus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_IngredientUnits_IngredientUnitId",
                table: "Ingredient",
                column: "IngredientUnitId",
                principalTable: "IngredientUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItem_Ingredient_IngredientId",
                table: "PurchaseItem",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

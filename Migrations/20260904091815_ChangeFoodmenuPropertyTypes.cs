using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSsystem.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFoodmenuPropertyTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
{
    // Convert VegItem: string -> boolean
    migrationBuilder.Sql("""
        ALTER TABLE "Foodmenus"
        ALTER COLUMN "VegItem"
        TYPE boolean
        USING CASE
            WHEN LOWER(TRIM("VegItem")) IN ('true', '1', 'yes') THEN true
            ELSE false
        END;
    """);

    // Convert Beverage: string -> boolean
    migrationBuilder.Sql("""
        ALTER TABLE "Foodmenus"
        ALTER COLUMN "Beverage"
        TYPE boolean
        USING CASE
            WHEN LOWER(TRIM("Beverage")) IN ('true', '1', 'yes') THEN true
            ELSE false
        END;
    """);

    // Convert Bar: string -> boolean
    migrationBuilder.Sql("""
        ALTER TABLE "Foodmenus"
        ALTER COLUMN "Bar"
        TYPE boolean
        USING CASE
            WHEN LOWER(TRIM("Bar")) IN ('true', '1', 'yes') THEN true
            ELSE false
        END;
    """);

    // Convert SalesPrice: string -> decimal
    migrationBuilder.Sql("""
        ALTER TABLE "Foodmenus"
        ALTER COLUMN "SalesPrice"
        TYPE numeric
        USING NULLIF(TRIM("SalesPrice"), '')::numeric;
    """);

    // Convert FoodingredientId: string -> integer
    migrationBuilder.Sql("""
        ALTER TABLE "Foodmenus"
        ALTER COLUMN "FoodingredientId"
        TYPE integer
        USING NULLIF(TRIM("FoodingredientId"), '')::integer;
    """);

    migrationBuilder.AlterColumn<string>(
        name: "Photo",
        table: "Foodmenus",
        type: "text",
        nullable: true,
        oldClrType: typeof(string),
        oldType: "text");

    migrationBuilder.AlterColumn<string>(
        name: "Description",
        table: "Foodmenus",
        type: "text",
        nullable: true,
        oldClrType: typeof(string),
        oldType: "text");
}
    }
}

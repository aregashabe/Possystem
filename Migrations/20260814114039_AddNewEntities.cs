using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace POSsystem.Migrations
{
    /// <inheritdoc />
    public partial class AddNewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosOrders_Customers_CustomerId",
                table: "PosOrders");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "PosOrders",
                newName: "VatAmount");

            migrationBuilder.RenameColumn(
                name: "OrderNumber",
                table: "PosOrders",
                newName: "Options");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "PosOrders",
                newName: "Date");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "PosOrders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "AddedById",
                table: "PosOrders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillNumber",
                table: "PosOrders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CancelById",
                table: "PosOrders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "PosOrders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GrandTotal",
                table: "PosOrders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Hold",
                table: "PosOrders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpenToken",
                table: "PosOrders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "PosOrders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentType",
                table: "PosOrders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "PosOrders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "PosOrders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "WaiterId",
                table: "PosOrders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeliveryName = table.Column<string>(type: "text", nullable: false),
                    DeliveryMobile = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SupplierName = table.Column<string>(type: "text", nullable: false),
                    SupplierEmail = table.Column<string>(type: "text", nullable: false),
                    SupplierMobile = table.Column<string>(type: "text", nullable: false),
                    SupplierAddress = table.Column<string>(type: "text", nullable: false),
                    TaxNumber = table.Column<string>(type: "text", nullable: false),
                    LicenseNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tabless",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TableName = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    SeatCapacity = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabless", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Firstname = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    userRole = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VatName = table.Column<string>(type: "text", nullable: false),
                    Percentage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Waiters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WaiterName = table.Column<string>(type: "text", nullable: false),
                    Designation = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waiters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceNumber = table.Column<string>(type: "text", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    DueAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    GrandTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DesignationName = table.Column<string>(type: "text", nullable: false),
                    data = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Designations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foodmenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FoodmenuName = table.Column<string>(type: "text", nullable: false),
                    CatagoryId = table.Column<int>(type: "integer", nullable: false),
                    FoodingredientId = table.Column<string>(type: "text", nullable: false),
                    SalesPrice = table.Column<string>(type: "text", nullable: false),
                    VatId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    VegItem = table.Column<string>(type: "text", nullable: false),
                    Beverage = table.Column<string>(type: "text", nullable: false),
                    Bar = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foodmenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foodmenus_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Foodmenus_Vats_VatId",
                        column: x => x.VatId,
                        principalTable: "Vats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    IngredientUnitId = table.Column<int>(type: "integer", nullable: false),
                    AlertQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FoodmenuId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredient_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredient_Foodmenus_FoodmenuId",
                        column: x => x.FoodmenuId,
                        principalTable: "Foodmenus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ingredient_IngredientUnits_IngredientUnitId",
                        column: x => x.IngredientUnitId,
                        principalTable: "IngredientUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PosOrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PosOrderId = table.Column<int>(type: "integer", nullable: false),
                    FoodMenuId = table.Column<int>(type: "integer", nullable: false),
                    SalesPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosOrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PosOrderItem_Foodmenus_FoodMenuId",
                        column: x => x.FoodMenuId,
                        principalTable: "Foodmenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PosOrderItem_PosOrders_PosOrderId",
                        column: x => x.PosOrderId,
                        principalTable: "PosOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PurchaseId = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseItem_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseItem_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PosOrders_AddedById",
                table: "PosOrders",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_PosOrders_CancelById",
                table: "PosOrders",
                column: "CancelById");

            migrationBuilder.CreateIndex(
                name: "IX_PosOrders_DeliveryId",
                table: "PosOrders",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_PosOrders_TableId",
                table: "PosOrders",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_PosOrders_WaiterId",
                table: "PosOrders",
                column: "WaiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_UserId",
                table: "Designations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Foodmenus_CategoryId",
                table: "Foodmenus",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Foodmenus_VatId",
                table: "Foodmenus",
                column: "VatId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_CategoryId",
                table: "Ingredient",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_FoodmenuId",
                table: "Ingredient",
                column: "FoodmenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_IngredientUnitId",
                table: "Ingredient",
                column: "IngredientUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PosOrderItem_FoodMenuId",
                table: "PosOrderItem",
                column: "FoodMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_PosOrderItem_PosOrderId",
                table: "PosOrderItem",
                column: "PosOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_SupplierId",
                table: "Purchase",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItem_IngredientId",
                table: "PurchaseItem",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItem_PurchaseId",
                table: "PurchaseItem",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PosOrders_Customers_CustomerId",
                table: "PosOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PosOrders_Deliveries_DeliveryId",
                table: "PosOrders",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PosOrders_Tabless_TableId",
                table: "PosOrders",
                column: "TableId",
                principalTable: "Tabless",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PosOrders_Users_AddedById",
                table: "PosOrders",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PosOrders_Users_CancelById",
                table: "PosOrders",
                column: "CancelById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PosOrders_Waiters_WaiterId",
                table: "PosOrders",
                column: "WaiterId",
                principalTable: "Waiters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosOrders_Customers_CustomerId",
                table: "PosOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PosOrders_Deliveries_DeliveryId",
                table: "PosOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PosOrders_Tabless_TableId",
                table: "PosOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PosOrders_Users_AddedById",
                table: "PosOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PosOrders_Users_CancelById",
                table: "PosOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PosOrders_Waiters_WaiterId",
                table: "PosOrders");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "PosOrderItem");

            migrationBuilder.DropTable(
                name: "PurchaseItem");

            migrationBuilder.DropTable(
                name: "Tabless");

            migrationBuilder.DropTable(
                name: "Waiters");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Foodmenus");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Vats");

            migrationBuilder.DropIndex(
                name: "IX_PosOrders_AddedById",
                table: "PosOrders");

            migrationBuilder.DropIndex(
                name: "IX_PosOrders_CancelById",
                table: "PosOrders");

            migrationBuilder.DropIndex(
                name: "IX_PosOrders_DeliveryId",
                table: "PosOrders");

            migrationBuilder.DropIndex(
                name: "IX_PosOrders_TableId",
                table: "PosOrders");

            migrationBuilder.DropIndex(
                name: "IX_PosOrders_WaiterId",
                table: "PosOrders");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "PosOrders");

            migrationBuilder.DropColumn(
                name: "BillNumber",
                table: "PosOrders");

            migrationBuilder.DropColumn(
                name: "CancelById",
                table: "PosOrders");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "PosOrders");

            migrationBuilder.DropColumn(
                name: "GrandTotal",
                table: "PosOrders");

            migrationBuilder.DropColumn(
                name: "Hold",
                table: "PosOrders");

            migrationBuilder.DropColumn(
                name: "OpenToken",
                table: "PosOrders");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "PosOrders");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "PosOrders");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "PosOrders");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "PosOrders");

            migrationBuilder.DropColumn(
                name: "WaiterId",
                table: "PosOrders");

            migrationBuilder.RenameColumn(
                name: "VatAmount",
                table: "PosOrders",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "Options",
                table: "PosOrders",
                newName: "OrderNumber");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "PosOrders",
                newName: "OrderDate");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "PosOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PosOrders_Customers_CustomerId",
                table: "PosOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

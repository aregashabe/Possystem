using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSsystem.Migrations
{
    /// <inheritdoc />
    public partial class RemoveShiftAndOpenToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosOrders_Tabless_TableId",
                table: "PosOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tabless",
                table: "Tabless");

            migrationBuilder.RenameTable(
                name: "Tabless",
                newName: "Tables");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tables",
                table: "Tables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PosOrders_Tables_TableId",
                table: "PosOrders",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosOrders_Tables_TableId",
                table: "PosOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tables",
                table: "Tables");

            migrationBuilder.RenameTable(
                name: "Tables",
                newName: "Tabless");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tabless",
                table: "Tabless",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PosOrders_Tabless_TableId",
                table: "PosOrders",
                column: "TableId",
                principalTable: "Tabless",
                principalColumn: "Id");
        }
    }
}

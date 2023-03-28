using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Migrations
{
    /// <inheritdoc />
    public partial class _105 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Orders_OrderId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId1",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderId1",
                table: "Orders",
                column: "OrderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Orders_OrderId1",
                table: "Orders",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}

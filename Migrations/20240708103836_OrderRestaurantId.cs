using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantsWebApi.Migrations
{
    public partial class OrderRestaurantId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_RestaurantId",
                table: "Order",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Restaurant_RestaurantId",
                table: "Order",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Restaurant_RestaurantId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_RestaurantId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Order");
        }
    }
}

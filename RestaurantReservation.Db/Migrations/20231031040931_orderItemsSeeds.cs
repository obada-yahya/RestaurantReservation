using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    public partial class orderItemsSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id","OrderId", "MenuItemId", "Quantity" },
                values: new object[,]
                {
                    {1, 1, 1, 2 },
                    {2, 1, 2, 1 },
                    {3, 2, 3, 3 },
                    {4, 2, 4, 2 },
                    {5, 3, 5, 2 },
                    {6, 3, 6, 1 },
                    {7, 4, 7, 1 },
                    {8, 4, 8, 2 },
                    {9, 5, 9, 2 },
                    {10 ,5, 10, 3 },
                    {11, 6, 1, 2 },
                    {12, 6, 2, 1 },
                    {13, 7, 3, 3 },
                    {14, 7, 4, 2 },
                    {15, 8, 5, 2 },
                    {16, 8, 6, 1 },
                    {17, 9, 7, 1 },
                    {18, 9, 8, 2 },
                    {19, 10, 9, 2 },
                    {20, 10, 10, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    public partial class restaurantSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[] { 1, "california", "The Rustic Bistro", "11:00 AM - 9:00 PM", "(555) 123-4567" });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[] { 2, "New York", "Bella Vita Trattoria", "11:00 AM - 9:00 PM", "(555) 987-6543" });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[] { 3, "texas", "The Spice Garden Grill", "11:00 AM - 9:00 PM", "(555) 789-0123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

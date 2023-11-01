using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    public partial class reservationSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "RestaurantId", "TableId", "ReservationDate", "PartySize" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, new DateTime(2023, 10, 31, 14, 30, 0), 5 },
                    { 2, 2, 2, 2, new DateTime(2023, 10, 10, 16, 30, 0), 5 },
                    { 3, 3, 3, 3, new DateTime(2023, 10, 20, 12, 30, 0), 5 },
                    { 4, 4, 1, 4, new DateTime(2023, 10, 25, 15, 30, 0), 9 },
                    { 5, 5, 2, 5, new DateTime(2023, 10, 28, 18, 30, 0), 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Reservations", "Id", new object[] { 1 });
            migrationBuilder.DeleteData("Reservations", "Id", new object[] { 2 });
            migrationBuilder.DeleteData("Reservations", "Id", new object[] { 3 });
            migrationBuilder.DeleteData("Reservations", "Id", new object[] { 4 });
            migrationBuilder.DeleteData("Reservations", "Id", new object[] { 5 });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    public partial class orderSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ReservationId", "EmployeeId", "OrderDate", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2023, 10, 31, 14, 50, 0), 50.99f },
                    { 2, 2, 3, new DateTime(2023, 10, 10, 16, 45, 0), 45.99f },
                    { 3, 3, 5, new DateTime(2023, 10, 20, 12, 58, 0), 40.99f },
                    { 4, 4, 2, new DateTime(2023, 11, 5, 18, 15, 0), 38.99f },
                    { 5, 5, 4, new DateTime(2023, 11, 8, 20, 0, 0), 55.99f },
                    
                    { 6, 1, 2, new DateTime(2023, 10, 31, 14, 55, 0), 30.99f },
                    { 7, 2, 10, new DateTime(2023, 10, 10, 16, 49, 0), 25.99f },
                    { 8, 3, 8, new DateTime(2023, 10, 20, 13, 0, 0), 69.99f },
                    { 9, 4, 7, new DateTime(2023, 11, 5, 18, 25, 0), 27.99f },
                    { 10, 5, 9, new DateTime(2023, 11, 8, 20, 15, 0), 67.99f },

                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }
    }
}

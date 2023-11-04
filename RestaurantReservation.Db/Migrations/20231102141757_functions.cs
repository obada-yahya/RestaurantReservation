using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    public partial class functions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE FUNCTION CalculateTotalRevenueOfRestaurant(@restaurantId INT)
            RETURNS FLOAT AS 
            BEGIN
            RETURN (SELECT SUM(Orders.TotalAmount)
		            FROM Reservations 
		            INNER JOIN Orders 
		            ON Reservations.Id = Orders.ReservationId 
		            WHERE Reservations.RestaurantId = @restaurantId)
            END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION CalculateTotalRevenueOfRestaurant");
        }
    }
}

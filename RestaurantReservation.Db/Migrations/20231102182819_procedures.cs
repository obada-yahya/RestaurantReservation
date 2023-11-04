using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    public partial class Procedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE dbo.FindCustomersWithPartySizeGreaterThan
            @partySize INT 
            AS
            SELECT  Customers.*
		    FROM Reservations
		    INNER JOIN Customers 
		    ON Reservations.CustomerId = Customers.Id
		    WHERE Reservations.PartySize > @partySize");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.FindCustomersWithPartySizeGreaterThan");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    public partial class Views : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql(@"CREATE VIEW ReservationsFullDetails
                  AS
                  SELECT 
						 ReservationDate
						 ,PartySize
				         ,FirstName + ' '+ LastName as CustomerName
						 ,Customers.PhoneNumber as CustomerPhoneNumber
						 ,Email as CustomerEmail
						 ,Restaurants.Name as RestaurantName
						 ,Restaurants.Address as RestaurantAddress
						 ,Restaurants.OpeningHours as RestaurantOpeningHours
						 ,Restaurants.PhoneNumber as RestaurantPhoneNumber
                  FROM Reservations INNER JOIN
                  Restaurants ON Restaurants.Id = Reservations.RestaurantId INNER JOIN
				  Customers ON Customers.Id = Reservations.CustomerId;
				 ");
	        
	        migrationBuilder.Sql(@"CREATE VIEW EmployeesWithRestaurantDetails 
			   AS
			   SELECT 
					   Employees.FirstName + ' ' + Employees.LastName AS EmpName
					  ,Employees.Position AS EmpPosition
					  ,Restaurants.Name as RestaurantName
					  ,Restaurants.Address as RestaurantAddress
					  ,Restaurants.OpeningHours as RestaurantOpeningHours
					  ,Restaurants.PhoneNumber as RestaurantPhoneNumber
			  FROM Employees INNER JOIN Restaurants 
			  ON Restaurants.Id = Employees.RestaurantId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql("DROP VIEW ReservationsFullDetails");
	        migrationBuilder.Sql("DROP VIEW EmployeesWithRestaurantDetails");
        }
    }
}

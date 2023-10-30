using RestaurantReservation.Db;

namespace RestaurantReservation;

public class Program
{
    static void Main(string[] args)
    {
        var context = new RestaurantReservationDbContext();
        context.Database.EnsureCreated();
    }
}
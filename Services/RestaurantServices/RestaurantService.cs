using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Services.Interfaces;

namespace RestaurantReservation.Services.RestaurantServices;

public class RestaurantService: IRestaurantService
{
    private readonly RestaurantReservationDbContext _context;

    public RestaurantService(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public void AddRestaurant(Restaurant restaurant)
    {
        try
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public IEnumerable<Restaurant> GetRestaurants()
    {
        try
        {
            return _context.Restaurants;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<Restaurant>();
    }
    
    public Restaurant? FindRestaurant(int id)
    {
        try
        {
            return _context.Restaurants.Single(restaurant => restaurant.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    
    public void UpdateRestaurant(Restaurant restaurant)
    {
        try
        {
            _context.Restaurants.Update(restaurant);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public void DeleteRestaurant(int id)
    {
        try
        {
            _context.Restaurants.Remove(new Restaurant(){Id = id});
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
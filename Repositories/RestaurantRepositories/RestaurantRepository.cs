using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Repositories.RestaurantRepositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly RestaurantReservationDbContext _context;

    public RestaurantRepository(RestaurantReservationDbContext restaurantReservationDbContext)
    {
        _context = restaurantReservationDbContext;
    }

    public async Task<Restaurant?> AddRestaurantAsync(Restaurant restaurant)
    {
        try
        {
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
            return restaurant;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public async Task<IEnumerable<Restaurant>> GetRestaurantsAsync()
    {
        try
        {
            return await _context.Restaurants.AsNoTracking().ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<Restaurant>();
    }

    public async Task<Restaurant?> FindRestaurantAsync(int id)
    {
        try
        {
            return await _context
                .Restaurants
                .AsNoTracking()
                .SingleAsync(restaurant => restaurant.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public async Task UpdateRestaurantAsync(Restaurant restaurant)
    {
        _context.Restaurants.Update(restaurant);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRestaurantAsync(int id)
    {
        _context.Restaurants.Remove(new Restaurant() { Id = id });
        await _context.SaveChangesAsync();
    }
}
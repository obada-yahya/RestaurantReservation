using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Dtos;

namespace RestaurantReservation.Services.RestaurantServices;

public class RestaurantService: IRestaurantService
{
    private readonly RestaurantReservationDbContext _context;
    private readonly IMapper _mapper; 

    public RestaurantService(RestaurantReservationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public RestaurantDto AddRestaurant(RestaurantForCreationDto restaurant)
    {
        try
        {
            var restaurantDomain = _mapper.Map<Restaurant>(restaurant);
            _context.Restaurants.Add(restaurantDomain);
            _context.SaveChanges();
            return _mapper.Map<RestaurantDto>(restaurantDomain);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null!;
    }

    public IEnumerable<RestaurantDto> GetRestaurants()
    {
        try
        {
            return _mapper
                   .Map<IEnumerable<RestaurantDto>>
                   (_context.Restaurants.AsNoTracking());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<RestaurantDto>();
    }
    
    public RestaurantDto? FindRestaurant(int id)
    {
        try
        {
            var restaurantModel = _context
                .Restaurants
                .AsNoTracking()
                .Single(restaurant => restaurant.Id == id);
            return _mapper.Map<RestaurantDto>(restaurantModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    
    public void UpdateRestaurant(RestaurantDto restaurant)
    {
        try
        {
            var restaurantDto = _mapper.Map<Restaurant>(restaurant);
            _context.Restaurants.Update(restaurantDto);
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
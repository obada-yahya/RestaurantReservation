using AutoMapper;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Dtos;
using RestaurantReservation.Repositories.RestaurantRepositories;

namespace RestaurantReservation.Services.RestaurantServices;

public class RestaurantService: IRestaurantService
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IMapper _mapper; 

    public RestaurantService(IMapper mapper, IRestaurantRepository restaurantRepository)
    {
        _mapper = mapper;
        _restaurantRepository = restaurantRepository;
    }

    public async Task<RestaurantDto?> AddRestaurant(RestaurantForCreationDto restaurant)
    {
        try
        {
            var restaurantDomain = _mapper.Map<Restaurant>(restaurant);
            restaurantDomain = await _restaurantRepository.AddRestaurant(restaurantDomain);
            return _mapper.Map<RestaurantDto>(restaurantDomain);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public async Task<IEnumerable<RestaurantDto>> GetRestaurants()
    {
        try
        {
            return _mapper.Map<IEnumerable<RestaurantDto>>(await _restaurantRepository.GetRestaurants());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<RestaurantDto>();
    }
    
    public async Task<RestaurantDto?> FindRestaurant(int id)
    {
        try
        {
            var restaurantModel = await _restaurantRepository.FindRestaurant(id);
            return _mapper.Map<RestaurantDto>(restaurantModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    
    public async Task UpdateRestaurant(RestaurantDto restaurant)
    {
        try
        {
            var restaurantModel = _mapper.Map<Restaurant>(restaurant);
            await _restaurantRepository.UpdateRestaurant(restaurantModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public async Task DeleteRestaurant(int id)
    {
        try
        {
            await _restaurantRepository.DeleteRestaurant(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
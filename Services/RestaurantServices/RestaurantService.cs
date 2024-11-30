using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Dtos.RestaurantDtos;
using RestaurantReservation.Repositories.RestaurantRepositories;

namespace RestaurantReservation.Services.RestaurantServices;

public class RestaurantService: IRestaurantService
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IMapper _mapper; 

    public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
    {
        _restaurantRepository = restaurantRepository;
        _mapper = mapper;
    }

    public async Task<RestaurantDto?> AddRestaurantAsync(RestaurantForCreationDto restaurant)
    {
        try
        {
            var restaurantModel = _mapper.Map<Restaurant>(restaurant);
            restaurantModel = await _restaurantRepository.AddRestaurantAsync(restaurantModel);
            return _mapper.Map<RestaurantDto>(restaurantModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<RestaurantDto>> GetRestaurantsAsync()
    {
        try
        {
            return _mapper.Map<IEnumerable<RestaurantDto>>
                (await _restaurantRepository.GetRestaurantsAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<RestaurantDto>();
    }
    
    public async Task<RestaurantDto?> FindRestaurantAsync(int id)
    {
        try
        {
            var restaurantModel = await _restaurantRepository.FindRestaurantAsync(id);
            return _mapper.Map<RestaurantDto>(restaurantModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    
    public async Task UpdateRestaurantAsync(RestaurantDto restaurant)
    {
        try
        {
            var restaurantModel = _mapper.Map<Restaurant>(restaurant);
            await _restaurantRepository.UpdateRestaurantAsync(restaurantModel);
        }
        catch (DbUpdateException e)
        {
            throw new InvalidDataException("The Data Violates Database Constraints");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public async Task DeleteRestaurantAsync(int id)
    {
        try
        {
            await _restaurantRepository.DeleteRestaurantAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
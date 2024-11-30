using RestaurantReservation.Dtos.RestaurantDtos;

namespace RestaurantReservation.Services.RestaurantServices;

public interface IRestaurantService
{
    public Task<RestaurantDto?> AddRestaurantAsync(RestaurantForCreationDto restaurant);
    public Task<IEnumerable<RestaurantDto>> GetRestaurantsAsync();
    public Task<RestaurantDto?> FindRestaurantAsync(int id);
    public Task UpdateRestaurantAsync(RestaurantDto restaurant);
    public Task DeleteRestaurantAsync(int id);
}
using RestaurantReservation.Dtos;

namespace RestaurantReservation.Services.RestaurantServices;

public interface IRestaurantService
{
    public Task<RestaurantDto?> AddRestaurant(RestaurantForCreationDto restaurant);
    public Task<IEnumerable<RestaurantDto>> GetRestaurants();
    public Task<RestaurantDto?> FindRestaurant(int id);
    public Task UpdateRestaurant(RestaurantDto restaurant);
    public Task DeleteRestaurant(int id);
}
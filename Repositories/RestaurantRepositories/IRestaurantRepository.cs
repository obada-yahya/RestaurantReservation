using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Dtos;

namespace RestaurantReservation.Repositories.RestaurantRepositories;

public interface IRestaurantRepository
{
    public Task<Restaurant?> AddRestaurantAsync(Restaurant restaurant);
    public Task<IEnumerable<Restaurant>> GetRestaurantsAsync();
    public Task<Restaurant?> FindRestaurantAsync(int id);
    public Task UpdateRestaurantAsync(Restaurant restaurant);
    public Task DeleteRestaurantAsync(int id);
}
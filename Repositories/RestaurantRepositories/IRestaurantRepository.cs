using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Dtos;

namespace RestaurantReservation.Repositories.RestaurantRepositories;

public interface IRestaurantRepository
{
    public Task<Restaurant?> AddRestaurant(Restaurant restaurant);
    public Task<IEnumerable<Restaurant>> GetRestaurants();
    public Task<Restaurant?> FindRestaurant(int id);
    public Task UpdateRestaurant(Restaurant restaurant);
    public Task DeleteRestaurant(int id);
}
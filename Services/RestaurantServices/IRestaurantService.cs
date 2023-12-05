using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Services.RestaurantServices;

public interface IRestaurantService
{
    public Restaurant AddRestaurant(Restaurant restaurant);
    public IEnumerable<Restaurant> GetRestaurants();
    public Restaurant? FindRestaurant(int id);
    public void UpdateRestaurant(Restaurant restaurant);
    public void DeleteRestaurant(int id);
}
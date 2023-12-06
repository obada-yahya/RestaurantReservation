using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Dtos;

namespace RestaurantReservation.Services.RestaurantServices;

public interface IRestaurantService
{
    public RestaurantDto AddRestaurant(RestaurantForCreationDto restaurant);
    public IEnumerable<RestaurantDto> GetRestaurants();
    public RestaurantDto? FindRestaurant(int id);
    public void UpdateRestaurant(RestaurantDto restaurant);
    public void DeleteRestaurant(int id);
}
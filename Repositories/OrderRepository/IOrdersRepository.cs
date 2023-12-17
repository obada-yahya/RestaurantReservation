using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Repositories.OrderRepository;

public interface IOrdersRepository
{
    public Task<Order?> AddOrderAsync(Order order);
    public Task<IEnumerable<Order>> GetOrdersAsync();
    public Task<Order?> FindOrderAsync(int id);
    public Task UpdateOrderAsync(Order order);
    public Task DeleteOrderAsync(int id);
}
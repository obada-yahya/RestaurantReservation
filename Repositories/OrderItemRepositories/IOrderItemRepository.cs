using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Repositories.OrderItemRepositories;

public interface IOrderItemRepository
{
    public Task<OrderItems?> AddOrderItemAsync(OrderItems orderItems);
    public Task<IEnumerable<OrderItems>> GetOrderItemsAsync();
    public Task<OrderItems?> FindOrderItemAsync(int id);
    public Task UpdateOrderItemAsync(OrderItems orderItems);
    public Task DeleteOrderItemAsync(int id);
}
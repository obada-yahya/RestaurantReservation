using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Services.OrderItemsServices;

public interface IOrderItemsService
{
    public void AddOrderItem(OrderItems orderItems);
    public IEnumerable<OrderItems> GetOrderItems();
    public OrderItems? FindOrderItems(int id);
    public void UpdateOrderItems(OrderItems orderItems);
    public void DeleteOrderItems(int id);
}
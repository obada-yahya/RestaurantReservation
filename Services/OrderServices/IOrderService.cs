using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Services.OrderServices;

public interface IOrderService
{
    public void AddOrder(Order order);
    public IEnumerable<Order> GetOrders();
    public Order? FindOrder(int id);
    public void UpdateOrder(Order order);
    public void DeleteOrder(int id);
}
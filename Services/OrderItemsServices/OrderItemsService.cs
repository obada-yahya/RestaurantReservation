using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Services.OrderItemsServices;

public class OrderItemsService: IOrderItemsService
{
    private readonly RestaurantReservationDbContext _context;

    public OrderItemsService(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public void AddOrderItem(OrderItems orderItems)
    {
        try
        {
            _context.OrderItems.Add(orderItems);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public IEnumerable<OrderItems> GetOrderItems()
    {
        try
        {
            return _context.OrderItems;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<OrderItems>();
    }
    
    public OrderItems? FindOrderItems(int id)
    {
        try
        {
            return _context
                .OrderItems
                .Single(order => order.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    
    public void UpdateOrderItems(OrderItems orderItems)
    {
        try
        {
            _context.OrderItems.Update(orderItems);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public void DeleteOrderItems(int id)
    {
        try
        {
            _context.OrderItems.Remove(new OrderItems(){Id = id});
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
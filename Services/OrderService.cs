using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Services;

public class OrderService
{
    private readonly RestaurantReservationDbContext _context;

    public OrderService(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public void AddOrder(Order order)
    {
        try
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public IEnumerable<Order> GetOrders()
    {
        try
        {
            return _context.Orders
                   .Include(order => order.OrderItems);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<Order>();
    }
    
    public Order? FindOrder(int id)
    {
        try
        {
            return _context
                .Orders
                .Include(order => order.OrderItems)
                .Single(order => order.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    
    public void UpdateOrder(Order order)
    {
        try
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public void DeleteOrder(int id)
    {
        try
        {
            _context.Orders.Remove(new Order(){Id = id});
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Repositories.OrderRepository;

public class OrderRepository : IOrdersRepository
{
    private readonly RestaurantReservationDbContext _context;

    public OrderRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Order?> AddOrderAsync(Order order)
    {
        try
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }
        catch (DbUpdateException e)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        try
        {
            return await _context
                .Orders
                .AsNoTracking()
                .Include(order => order.OrderItems)
                .ThenInclude(orderItem => orderItem.MenuItem)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<Order>();
    }

    public async Task<Order?> FindOrderAsync(int id)
    {
        try
        {
            return await _context
                .Orders
                .AsNoTracking()
                .Include(order => order.OrderItems)
                .ThenInclude(orderItem => orderItem.MenuItem)
                .SingleAsync(order => order.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public async Task UpdateOrderAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(int id)
    {
        _context.Orders.Remove(new Order(){Id = id});
        await _context.SaveChangesAsync();
    }
}
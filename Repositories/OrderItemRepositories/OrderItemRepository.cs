using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Repositories.OrderItemRepositories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly RestaurantReservationDbContext _context;

    public OrderItemRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<OrderItems?> AddOrderItemAsync(OrderItems orderItems)
    {
        try
        {
            await _context.OrderItems.AddAsync(orderItems);
            await _context.SaveChangesAsync();
            return orderItems;
        }
        catch (DbUpdateException e)
        {
            return null;
        }
    }

    public async Task<IEnumerable<OrderItems>> GetOrderItemsAsync()
    {
        try
        {
            return await _context
                .OrderItems
                .AsNoTracking()
                .Include(orderItem
                    => orderItem.MenuItem)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<OrderItems>();
    }

    public async Task<OrderItems?> FindOrderItemAsync(int id)
    {
        try
        {
            return await _context
                .OrderItems
                .AsNoTracking()
                .Include(orderItem
                    => orderItem.MenuItem)
                .SingleAsync(order => order.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public async Task UpdateOrderItemAsync(OrderItems orderItems)
    {
        _context.OrderItems.Update(orderItems);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrderItemAsync(int id)
    {
        _context.OrderItems.Remove(new OrderItems(){Id = id});
        await _context.SaveChangesAsync();
    }
}
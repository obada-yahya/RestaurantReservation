using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Repositories.MenuItemRepositories;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly RestaurantReservationDbContext _context;

    public MenuItemRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<MenuItem?> AddMenuItemAsync(MenuItem menuItem)
    {
        try
        {
            await _context.MenuItems.AddAsync(menuItem);
            await _context.SaveChangesAsync();
            return menuItem;
        }
        catch (DbUpdateException e)
        {
            return null;
        }
    }

    public async Task<IEnumerable<MenuItem>> GetMenuItemsAsync()
    {
        try
        {
            return await _context
                .MenuItems
                .AsNoTracking()
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<MenuItem>();
    }

    public async Task<MenuItem?> FindMenuItemAsync(int id)
    {
        try
        {
            return await _context
                .MenuItems
                .AsNoTracking()
                .SingleAsync(menuItem => menuItem.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public async Task UpdateMenuItemAsync(MenuItem menuItem)
    {
        _context.MenuItems.Update(menuItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMenuItemAsync(int id)
    {
        _context.MenuItems.Remove(new MenuItem(){Id = id});
        await _context.SaveChangesAsync();
    }
}
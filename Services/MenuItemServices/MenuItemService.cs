using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Services.MenuItemServices;

public class MenuItemService : IMenuItemService
{
    private readonly RestaurantReservationDbContext _context;

    public MenuItemService(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public void AddMenuItem(MenuItem menuItem)
    {
        try
        {
            _context.MenuItems.Add(menuItem);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public IEnumerable<MenuItem> GetMenuItems()
    {
        try
        {
            return _context.MenuItems;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<MenuItem>();
    }
    
    public MenuItem? FindMenuItem(int id)
    {
        try
        {
            return _context.MenuItems
                   .Single(order => order.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    
    public void UpdateMenuItem(MenuItem menuItem)
    {
        try
        {
            _context.MenuItems.Update(menuItem);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public void DeleteMenuItem(int id)
    {
        try
        {
            _context.MenuItems.Remove(new MenuItem(){Id = id});
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
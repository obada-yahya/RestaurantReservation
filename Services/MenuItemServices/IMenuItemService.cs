using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Services.MenuItemServices;

public interface IMenuItemService
{
    public void AddMenuItem(MenuItem menuItem);
    public IEnumerable<MenuItem> GetMenuItems();
    public MenuItem? FindMenuItem(int id);
    public void UpdateMenuItem(MenuItem menuItem);
    public void DeleteMenuItem(int id);
}
using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Services.Interfaces;

public interface IMenuItemService
{
    public void AddMenuItem(MenuItem menuItem);
    public IEnumerable<MenuItem> GetMenuItems();
    public MenuItem? FindMenuItem(int id);
    public void UpdateMenuItem(MenuItem menuItem);
    public void DeleteMenuItem(int id);
}
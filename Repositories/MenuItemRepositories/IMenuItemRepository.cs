using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Repositories.MenuItemRepositories;

public interface IMenuItemRepository
{
    public Task<MenuItem?> AddMenuItemAsync(MenuItem menuItem);
    public Task<IEnumerable<MenuItem>> GetMenuItemsAsync();
    public Task<MenuItem?> FindMenuItemAsync(int id);
    public Task UpdateMenuItemAsync(MenuItem menuItem);
    public Task DeleteMenuItemAsync(int id);
}
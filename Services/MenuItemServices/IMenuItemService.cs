
using RestaurantReservation.Dtos.MenuItemDtos;

namespace RestaurantReservation.Services.MenuItemServices;

public interface IMenuItemService
{
    public Task<MenuItemDto?> AddMenuItemAsync(MenuItemForCreationDto menuItem);
    public Task<IEnumerable<MenuItemDto>> GetMenuItemsAsync();
    public Task<MenuItemDto?> FindMenuItemAsync(int id);
    public Task UpdateMenuItemAsync(MenuItemDto menuItem);
    public Task DeleteMenuItemAsync(int id);
}
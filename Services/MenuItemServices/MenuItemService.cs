using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Dtos.MenuItemDtos;
using RestaurantReservation.Repositories.MenuItemRepositories;

namespace RestaurantReservation.Services.MenuItemServices;

public class MenuItemService : IMenuItemService
{
    private readonly IMenuItemRepository _menuItemRepository;
    private readonly IMapper _mapper;

    public MenuItemService(IMenuItemRepository menuItemRepository, IMapper mapper)
    {
        _menuItemRepository = menuItemRepository;
        _mapper = mapper;
    }

    public async Task<MenuItemDto?> AddMenuItemAsync(MenuItemForCreationDto menuItem)
    {
        try
        {
            var menuItemModel = _mapper.Map<MenuItem>(menuItem);
            menuItemModel = await _menuItemRepository.AddMenuItemAsync(menuItemModel);
            return _mapper.Map<MenuItemDto>(menuItemModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<MenuItemDto>> GetMenuItemsAsync()
    {
        try
        {
            return _mapper.Map<IEnumerable<MenuItemDto>>
                (await _menuItemRepository.GetMenuItemsAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<MenuItemDto>();
    }

    public async Task<MenuItemDto?> FindMenuItemAsync(int id)
    {
        try
        {
            var menuItemModel = await _menuItemRepository.FindMenuItemAsync(id);
            return _mapper.Map<MenuItemDto>(menuItemModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public async Task UpdateMenuItemAsync(MenuItemDto menuItem)
    {
        try
        {
            var menuItemModel = _mapper.Map<MenuItem>(menuItem);
            await _menuItemRepository.UpdateMenuItemAsync(menuItemModel);
        }
        catch (DbUpdateException e)
        {
            throw new InvalidDataException("The Data Violates Database Constraints");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public async Task DeleteMenuItemAsync(int id)
    {
        try
        {
            await _menuItemRepository.DeleteMenuItemAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
using AutoMapper;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Dtos.MenuItemDtos;

namespace RestaurantReservation.Profiles;

public class MenuItemProfile : Profile
{
    public MenuItemProfile()
    {
        CreateMap<MenuItemForCreationDto, MenuItem>();
        CreateMap<MenuItem, MenuItemDto>();
        CreateMap<MenuItemDto, MenuItem>();
        CreateMap<MenuItemForCreationDto, MenuItemDto>();
        CreateMap<MenuItemForUpdateDto, MenuItemDto>();
    }
}
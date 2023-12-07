using AutoMapper;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Dtos.RestaurantDtos;

namespace RestaurantReservation.Profiles;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<RestaurantForCreationDto, Restaurant>();
        CreateMap<Restaurant, RestaurantDto>();
        CreateMap<RestaurantForCreationDto, RestaurantDto>();
    }
}
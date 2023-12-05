using AutoMapper;
using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.API.Profiles;

public class RestaurantProfile: Profile
{
    public RestaurantProfile()
    {
        CreateMap<Dtos.RestaurantForCreationDto, Restaurant>();
    }
}
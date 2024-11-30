using AutoMapper;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Dtos.CustomerDtos;

namespace RestaurantReservation.Profiles;

public class CustomerProfile: Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerForCreationDto, Customer>();
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();
        CreateMap<CustomerForCreationDto, CustomerDto>();
        CreateMap<CustomerForUpdateDto, CustomerDto>();
    }
}
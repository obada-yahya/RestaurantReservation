using AutoMapper;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Dtos.EmployeeDtos;

namespace RestaurantReservation.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<EmployeeForCreationDto, Employee>();
        CreateMap<Employee, EmployeeDto>();
        CreateMap<EmployeeDto, Employee>();
        CreateMap<EmployeeForCreationDto, EmployeeDto>();
        CreateMap<EmployeeForUpdateDto, EmployeeDto>();
    }
}
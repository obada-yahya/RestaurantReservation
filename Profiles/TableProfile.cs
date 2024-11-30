using AutoMapper;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Dtos.RestaurantDtos;
using RestaurantReservation.Dtos.TableDtos;

namespace RestaurantReservation.Profiles;

public class TableProfile : Profile
{
    public TableProfile()
    {
        CreateMap<TableForCreationDto, Table>();
        CreateMap<Table, TableDto>();
        CreateMap<TableDto, Table>();
        CreateMap<TableForCreationDto, TableDto>();
        CreateMap<TableForUpdateDto, TableDto>();
    }
}
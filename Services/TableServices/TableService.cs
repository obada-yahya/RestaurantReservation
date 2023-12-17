using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Dtos.TableDtos;
using RestaurantReservation.Repositories.TableRepositories;

namespace RestaurantReservation.Services.TableServices;

public class TableService: ITableService
{
    private readonly ITableRepository _tableRepository;
    private readonly IMapper _mapper;

    public TableService(ITableRepository tableRepository, IMapper mapper)
    {
        _mapper = mapper;
        _tableRepository = tableRepository;
    }

    public async  Task<TableDto?> AddTableAsync(TableForCreationDto table)
    {
        try
        {
            var tableModel = _mapper.Map<Table>(table);
            tableModel = await _tableRepository.AddTableAsync(tableModel);
            return _mapper.Map<TableDto>(tableModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<TableDto>> GetTablesAsync()
    {
        try
        {
            return _mapper.Map<IEnumerable<TableDto>>
                (await _tableRepository.GetTablesAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<TableDto>();
    }
    
    public async Task<TableDto?> FindTableAsync(int id)
    {
        try
        {
            var tableModel = await _tableRepository.FindTableAsync(id);
            return _mapper.Map<TableDto>(tableModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    
    public async Task UpdateTableAsync(TableDto table)
    {
        try
        {
            var tableModel = _mapper.Map<Table>(table);
            await _tableRepository.UpdateTableAsync(tableModel);
        }
        catch (DbUpdateException)
        {
            throw new InvalidDataException("The Data Violates Database Constraints");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public async Task DeleteTableAsync(int id)
    {
        try
        {
            await _tableRepository.DeleteTableAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
using RestaurantReservation.Dtos.TableDtos;

namespace RestaurantReservation.Services.TableServices;

public interface ITableService
{
    public Task<TableDto?> AddTableAsync(TableForCreationDto table);
    public Task<IEnumerable<TableDto>> GetTablesAsync();
    public Task<TableDto?> FindTableAsync(int id);
    public Task UpdateTableAsync(TableDto table);
    public Task DeleteTableAsync(int id);
}
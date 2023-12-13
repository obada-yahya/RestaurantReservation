using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Repositories.TableRepositories;

public interface ITableRepository
{
    public Task<Table?> AddTableAsync(Table table);
    public Task<IEnumerable<Table>> GetTablesAsync();
    public Task<Table?> FindTableAsync(int id);
    public Task UpdateTableAsync(Table table);
    public Task DeleteTableAsync(int id);
}
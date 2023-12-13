using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Services.TableServices;

public interface ITableService
{
    public void AddTable(Table table);
    public IEnumerable<Table> GetTables();
    public Table? FindTable(int id);
    public void UpdateTable(Table table);
    public void DeleteTable(int id);
}
using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Services.Interfaces;

namespace RestaurantReservation.Services;

public class TableService: ITableService
{
    private readonly RestaurantReservationDbContext _context;

    public TableService(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public void AddTable(Table table)
    {
        try
        {
            _context.Tables.Add(table);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public IEnumerable<Table> GetTables()
    {
        try
        {
            return _context.Tables;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<Table>();
    }
    
    public Table? FindTable(int id)
    {
        try
        {
            return _context.Tables.Single(table => table.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    
    public void UpdateTable(Table table)
    {
        try
        {
            _context.Tables.Update(table);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public void DeleteTable(int id)
    {
        try
        {
            _context.Tables.Remove(new Table(){Id = id});
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
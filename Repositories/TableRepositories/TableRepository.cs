using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Repositories.TableRepositories;

public class TableRepository: ITableRepository
{
    private readonly RestaurantReservationDbContext _context;

    public TableRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<Table?> AddTableAsync(Table table)
    {
        try
        {
            await _context.Tables.AddAsync(table);
            await _context.SaveChangesAsync();
            return table;
        }
        catch (DbUpdateException e)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Table>> GetTablesAsync()
    {
        try
        {
            return await _context
                .Tables
                .AsNoTracking()
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<Table>();
    }

    public async Task<Table?> FindTableAsync(int id)
    {
        try
        {
            return await _context
                .Tables
                .AsNoTracking()
                .SingleAsync(table => table.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public async Task UpdateTableAsync(Table table)
    {
        _context.Tables.Update(table);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTableAsync(int id)
    {
        _context.Tables.Remove(new Table() { Id = id });
        await _context.SaveChangesAsync();
    }
}
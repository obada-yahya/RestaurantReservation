using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Repositories.EmployeeRepositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly RestaurantReservationDbContext _context;

    public EmployeeRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Employee?> AddEmployeeAsync(Employee employee)
    {
        try
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        try
        {
            return await _context
                .Employees
                .AsNoTracking()
                .Include(emp 
                => emp.OrdersServed)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<Employee>();
    }

    public async Task<Employee?> FindEmployeeAsync(int id)
    {
        try
        {
            return await _context
                .Employees
                .AsNoTracking()
                .Include(emp => emp.OrdersServed)
                .SingleAsync(emp => emp.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        _context.Employees.Remove(new Employee(){Id = id});
        await _context.SaveChangesAsync();
    }
}
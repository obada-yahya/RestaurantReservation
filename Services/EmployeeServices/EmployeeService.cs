using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Services.EmployeeServices;

public class EmployeeService : IEmployeeService
{
    private readonly RestaurantReservationDbContext _context;

    public EmployeeService(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public void AddEmployee(Employee employee)
    {
        try
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public IEnumerable<Employee> GetEmployees()
    {
        try
        {
            return _context.Employees.Include(employee => employee.OrdersServed);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<Employee>();
    }
    
    public Employee? FindEmployee(int id)
    {
        try
        {
            return _context.Employees
                   .Include(employee => employee.OrdersServed)
                   .Single(employee => employee.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    
    public void UpdateEmployee(Employee employee)
    {
        try
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public void DeleteEmployee(int id)
    {
        try
        {
            _context.Employees.Remove(new Employee(){Id = id});
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
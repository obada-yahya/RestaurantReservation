using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Services;

public class EmployeeService
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
    
    public Restaurant? FindRestaurant(int id)
    {
        try
        {
            return _context.Restaurants.Single(restaurant => restaurant.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    
    public void UpdateRestaurant(Restaurant restaurant)
    {
        try
        {
            _context.Restaurants.Update(restaurant);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public void DeleteRestaurant(int id)
    {
        try
        {
            _context.Restaurants.Remove(new Restaurant(){Id = id});
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
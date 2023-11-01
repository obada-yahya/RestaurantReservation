using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Services;

public class CustomerService
{
    private readonly RestaurantReservationDbContext _context;

    public CustomerService(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public void AddCustomer(Customer customer)
    {
        try
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public IEnumerable<Customer> GetCustomers()
    {
        try
        {
            return _context.Customers.Include(customer => customer.Reservations);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<Customer>();
    }
    
    public Customer? FindCustomer(int id)
    {
        try
        {
            return _context
                .Customers
                .Include(customer => customer.Reservations)
                .Single(customer => customer.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    
    public void UpdateCustomer(Customer customer)
    {
        try
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public void DeleteCustomer(int id)
    {
        try
        {
            _context.Customers.Remove(new Customer(){Id = id});
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
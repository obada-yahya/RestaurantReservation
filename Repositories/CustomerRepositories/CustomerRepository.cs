using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Repositories.CustomerRepositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly RestaurantReservationDbContext _context;

    public CustomerRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<Customer?> AddCustomerAsync(Customer customer)
    {
        try
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        try
        {
            return await _context
                .Customers
                .AsNoTracking()
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<Customer>();
    }

    public async Task<Customer?> FindCustomerAsync(int id)
    {
        try
        {
            return await _context
                .Customers
                .AsNoTracking()
                .SingleAsync(customer => customer.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(int id)
    {
        _context.Customers.Remove(new Customer(){Id = id});
        await _context.SaveChangesAsync();
    }
}
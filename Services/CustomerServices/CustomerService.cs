using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Repositories.CustomerRepositories;

namespace RestaurantReservation.Services.CustomerServices;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer?> AddCustomerAsync(Customer customer)
    {
        try
        {
            await _customerRepository.AddCustomerAsync(customer);
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
            return await _customerRepository.GetCustomersAsync();
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
            return await _customerRepository.FindCustomerAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    
    public async Task UpdateCustomerAsync(Customer customer)
    {
        try
        {
            await _customerRepository.UpdateCustomerAsync(customer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public async Task DeleteCustomerAsync(int id)
    {
        try
        {
            await _customerRepository.DeleteCustomerAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
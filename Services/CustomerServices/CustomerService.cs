using AutoMapper;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Dtos.CustomerDtos;
using RestaurantReservation.Repositories.CustomerRepositories;

namespace RestaurantReservation.Services.CustomerServices;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CustomerDto?> AddCustomerAsync(CustomerForCreationDto customer)
    {
        try
        {
            var customerModel = _mapper.Map<Customer>(customer);
            customerModel = await _customerRepository.AddCustomerAsync(customerModel);
            return _mapper.Map<CustomerDto>(customerModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
    {
        try
        {
            return _mapper.Map<IEnumerable<CustomerDto>>
                (await _customerRepository.GetCustomersAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<CustomerDto>();
    }
    
    public async Task<CustomerDto?> FindCustomerAsync(int id)
    {
        try
        {
            var customerModel = await _customerRepository.FindCustomerAsync(id);
            return _mapper.Map<CustomerDto>(customerModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    
    public async Task UpdateCustomerAsync(CustomerDto customer)
    {
        try
        {
            var customerModel = _mapper.Map<Customer>(customer);
            await _customerRepository.UpdateCustomerAsync(customerModel);
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
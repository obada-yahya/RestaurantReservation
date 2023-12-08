using RestaurantReservation.Dtos.CustomerDtos;

namespace RestaurantReservation.Services.CustomerServices;

public interface ICustomerService
{
    public Task<CustomerDto?> AddCustomerAsync(CustomerForCreationDto customer);
    public Task<IEnumerable<CustomerDto>> GetCustomersAsync();
    public Task<CustomerDto?> FindCustomerAsync(int id);
    public Task UpdateCustomerAsync(CustomerDto customer);
    public Task DeleteCustomerAsync(int id);
}
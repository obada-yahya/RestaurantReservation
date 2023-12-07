using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Repositories.CustomerRepositories;

public interface ICustomerRepository
{
    public Task<Customer?> AddCustomerAsync(Customer customer);
    public Task<IEnumerable<Customer>> GetCustomersAsync();
    public Task<Customer?> FindCustomerAsync(int id);
    public Task UpdateCustomerAsync(Customer customer);
    public Task DeleteCustomerAsync(int id);
}
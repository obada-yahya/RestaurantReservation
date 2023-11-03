using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Services;

public interface ICustomerService
{
    public void AddCustomer(Customer customer);
    public IEnumerable<Customer> GetCustomers();
    public Customer? FindCustomer(int id);
    public void UpdateCustomer(Customer customer);
    public void DeleteCustomer(int id);
}
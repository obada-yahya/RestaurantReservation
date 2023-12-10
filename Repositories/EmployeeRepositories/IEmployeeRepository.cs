using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Repositories.EmployeeRepositories;

public interface IEmployeeRepository
{
    public Task<Employee?> AddEmployeeAsync(Employee employee);
    public Task<IEnumerable<Employee>> GetEmployeesAsync();
    public Task<Employee?> FindEmployeeAsync(int id);
    public Task UpdateEmployeeAsync(Employee employee);
    public Task DeleteEmployeeAsync(int id);
}
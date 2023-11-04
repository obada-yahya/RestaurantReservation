using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Services.EmployeeServices;

public interface IEmployeeService
{
    public void AddEmployee(Employee employee);
    public IEnumerable<Employee> GetEmployees();
    public Employee? FindEmployee(int id);
    public void UpdateEmployee(Employee employee);
    public void DeleteEmployee(int id);
}
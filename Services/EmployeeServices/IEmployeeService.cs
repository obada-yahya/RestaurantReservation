using RestaurantReservation.Dtos.EmployeeDtos;

namespace RestaurantReservation.Services.EmployeeServices;

public interface IEmployeeService
{
    public Task<EmployeeDto?> AddEmployeeAsync(EmployeeForCreationDto employee);
    public Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
    public Task<EmployeeDto?> FindEmployeeAsync(int id);
    public Task UpdateEmployeeAsync(EmployeeDto employee);
    public Task DeleteEmployeeAsync(int id);
}
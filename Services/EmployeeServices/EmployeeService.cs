using AutoMapper;
using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Dtos.EmployeeDtos;
using RestaurantReservation.Repositories.EmployeeRepositories;

namespace RestaurantReservation.Services.EmployeeServices;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeService(RestaurantReservationDbContext context, IMapper mapper, IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }

    public async Task<EmployeeDto?> AddEmployeeAsync(EmployeeForCreationDto employee)
    {
        try
        {
            var employeeModel = _mapper.Map<Employee>(employee);
            employeeModel = await _employeeRepository.AddEmployeeAsync(employeeModel);
            return _mapper.Map<EmployeeDto>(employeeModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
    {
        try
        {
            return _mapper.Map<IEnumerable<EmployeeDto>>
                (await _employeeRepository.GetEmployeesAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<EmployeeDto>();
    }
    
    public async Task<EmployeeDto?> FindEmployeeAsync(int id)
    {
        try
        {
            var employeeModel = await _employeeRepository.FindEmployeeAsync(id);
            return _mapper.Map<EmployeeDto>(employeeModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public async Task UpdateEmployeeAsync(EmployeeDto employee)
    {
        try
        {
            var employeeModel = _mapper.Map<Employee>(employee);
            await _employeeRepository.UpdateEmployeeAsync(employeeModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public async Task DeleteEmployeeAsync(int id)
    {
        try
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
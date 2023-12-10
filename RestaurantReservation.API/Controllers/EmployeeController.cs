using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Dtos.EmployeeDtos;
using RestaurantReservation.Repositories.EmployeeRepositories;
using RestaurantReservation.Services.EmployeeServices;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly ILogger<EmployeeController> _logger;
    private readonly IMapper _mapper;

    public EmployeeController(ILogger<EmployeeController> logger, IMapper mapper, IEmployeeService employeeService)
    {
        _logger = logger;
        _mapper = mapper;
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployeeAsync()
    {
        return Ok(await _employeeService.GetEmployeesAsync());
    }
    
    [HttpGet("{employeeId:int}", Name = "FindEmployee")]
    public async Task<IActionResult> FindEmployeeAsync(int employeeId)
    {
        var employee = await _employeeService.FindEmployeeAsync(employeeId);
        if (employee is null)
        {
            return NotFound();
        }
        return Ok(employee);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddEmployeeAsync(EmployeeForCreationDto employeeForCreationDto)
    {
        try
        {
            var addedEmployee = await _employeeService.AddEmployeeAsync(employeeForCreationDto);
            return CreatedAtRoute(
                "FindEmployee",
                new
                {
                    EmployeeId = addedEmployee.Id
                },
                addedEmployee);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    
    [HttpPut("{employeeId:int}")]
    public async Task<IActionResult> UpdateEmployeeAsync(int employeeId, EmployeeForUpdateDto employeeForUpdateDto)
    {
        try
        {
            var employeeDto = await _employeeService.FindEmployeeAsync(employeeId);
            if (employeeDto is null)
            {
                return NotFound();
            }
            _mapper.Map(employeeForUpdateDto, employeeDto);
            await _employeeService.UpdateEmployeeAsync(employeeDto);
            return Ok($"The employee with ID {employeeId} has been successfully Updated.");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    
    [HttpDelete("{employeeId:int}")]
    public async Task<IActionResult> DeleteEmployeeAsync(int employeeId)
    {
        try
        {
            if (await _employeeService.FindEmployeeAsync(employeeId) is null)
            {
                return BadRequest("No employee was found with the specified ID.");
            }
            await _employeeService.DeleteEmployeeAsync(employeeId);
            return Ok($"The employee with ID {employeeId} has been successfully deleted.");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}
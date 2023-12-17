using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Dtos.CustomerDtos;
using RestaurantReservation.Services.CustomerServices;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;
    private readonly ILogger<CustomerController> _logger;
    private readonly IMapper _mapper;

    public CustomerController(IMapper mapper, ICustomerService customerService, ILogger<CustomerController> logger)
    {
        _mapper = mapper;
        _customerService = customerService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomersAsync()
    {
        return Ok(await _customerService.GetCustomersAsync());
    }
    
    [HttpGet("{customerId:int}", Name = "FindCustomer")]
    public async Task<IActionResult> FindCustomerAsync(int customerId)
    {
        var customer = await _customerService.FindCustomerAsync(customerId);
        if (customer is null)
        {
            return NotFound();
        }
        return Ok(customer);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddCustomerAsync(CustomerForCreationDto customerForCreationDto)
    {
        try
        {
            var addedCustomer = await _customerService.AddCustomerAsync(customerForCreationDto);
            
            if (addedCustomer is null) 
                return BadRequest("Unable to process your request due to data constraints violation");
            
            return CreatedAtRoute(
                "FindCustomer",
                new
                {
                    CustomerId = addedCustomer.Id
                },
                addedCustomer);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    
    [HttpPut("{customerId:int}")]
    public async Task<IActionResult> UpdateCustomerAsync(int customerId, CustomerForUpdateDto restaurantForUpdateDto)
    {
        try
        {
            var customerDto = await _customerService.FindCustomerAsync(customerId);
            if (customerDto is null)
            {
                return NotFound();
            }
            _mapper.Map(restaurantForUpdateDto, customerDto);
            await _customerService.UpdateCustomerAsync(customerDto);
            return Ok($"The customer with ID {customerId} has been successfully Updated.");
        }
        catch (InvalidDataException e)
        {
            _logger.LogCritical(e.Message);
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    
    [HttpDelete("{customerId:int}")]
    public async Task<IActionResult> DeleteCustomerAsync(int customerId)
    {
        try
        {
            if (await _customerService.FindCustomerAsync(customerId) is null)
            {
                return BadRequest("No customer was found with the specified ID.");
            }
            await _customerService.DeleteCustomerAsync(customerId);
            return Ok($"The customer with ID {customerId} has been successfully deleted.");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Dtos;
using RestaurantReservation.Services.RestaurantServices;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("api/Restaurant")]
public class RestaurantController : Controller
{
    private readonly IRestaurantService _restaurantService;
    private readonly ILogger<RestaurantController> _logger;

    public RestaurantController(IRestaurantService restaurantService, ILogger<RestaurantController> logger)
    {
        _restaurantService = restaurantService;
        _logger = logger;
    }
    
    [HttpGet("/Restaurants")]
    public async Task<IActionResult> GetRestaurants()
    {
        return Ok(await _restaurantService.GetRestaurants());
    }

    [HttpGet("/Restaurants/{restaurantId:int}", Name = "FindRestaurant")]
    public async Task<IActionResult> FindRestaurant(int restaurantId)
    {
        var restaurant = await _restaurantService.FindRestaurant(restaurantId);
        if (restaurant is null)
        {
            return NotFound();
        }
        return Ok(restaurant);
    }

    [HttpPost("/Restaurants")]
    public async Task<IActionResult> AddRestaurant(RestaurantForCreationDto restaurantForCreationDto)
    {
        try
        {
            var addRestaurant = await _restaurantService.AddRestaurant(restaurantForCreationDto);
            return CreatedAtRoute(
                "FindRestaurant",
                new
                {
                    restaurantId = addRestaurant.Id
                },
                addRestaurant);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    
    [HttpDelete("/Restaurants/{restaurantId:int}")]
    public async Task<IActionResult> DeleteRestaurant(int restaurantId)
    {
        try
        {
            if (await _restaurantService.FindRestaurant(restaurantId) is null)
            {
                return BadRequest("No restaurant was found with the specified ID.");
            }
            await _restaurantService.DeleteRestaurant(restaurantId);
            return Ok($"The restaurant with ID {restaurantId} has been successfully deleted.");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    
}
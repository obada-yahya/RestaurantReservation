using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Dtos;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Services.RestaurantServices;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("api/Restaurant")]
public class RestaurantController : Controller
{
    private readonly IRestaurantService _restaurantService;
    private readonly IMapper _mapper;
    private readonly ILogger<RestaurantController> _logger;

    public RestaurantController(IRestaurantService restaurantService, IMapper mapper, ILogger<RestaurantController> logger)
    {
        _restaurantService = restaurantService;
        _mapper = mapper;
        _logger = logger;
    }
    
    [HttpGet("/Restaurants")]
    public IActionResult GetRestaurants()
    {
        return Ok(_restaurantService.GetRestaurants());
    }

    [HttpGet("/Restaurants/{restaurantId:int}",Name = "FindRestaurant")]
    public IActionResult FindRestaurant(int restaurantId)
    {
        var restaurant = _restaurantService.FindRestaurant(restaurantId);
        if (restaurant is null)
        {
            return NotFound();
        }
        return Ok(restaurant);
    }
    
    [HttpDelete("/Restaurants/{restaurantId}")]
    public IActionResult DeleteRestaurant(int restaurantId)
    {
        if (_restaurantService.FindRestaurant(restaurantId) is null)
        {
            return BadRequest("No restaurant was found with the specified ID.");
        }
        _restaurantService.DeleteRestaurant(restaurantId);
        return Ok($"Deleted The Restaurant With {restaurantId}.");
    }

    [HttpPost("/Restaurants")]
    public IActionResult AddRestaurant(RestaurantForCreationDto restaurantForCreationDto)
    {
        try
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantForCreationDto);
            var addRestaurant = _restaurantService.AddRestaurant(restaurant);
            return CreatedAtRoute("FindRestaurant", new { restaurantId = addRestaurant.Id }, addRestaurant);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    
}
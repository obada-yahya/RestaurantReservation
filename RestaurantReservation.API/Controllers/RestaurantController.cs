using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Dtos.RestaurantDtos;
using RestaurantReservation.Services.RestaurantServices;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("api/Restaurant")]
public class RestaurantController : Controller
{
    private readonly IRestaurantService _restaurantService;
    private readonly ILogger<RestaurantController> _logger;
    private readonly IMapper _mapper;

    public RestaurantController(IRestaurantService restaurantService, ILogger<RestaurantController> logger, IMapper mapper)
    {
        _restaurantService = restaurantService;
        _logger = logger;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetRestaurantsAsync()
    {
        return Ok(await _restaurantService.GetRestaurantsAsync());
    }

    [HttpGet("{restaurantId:int}", Name = "FindRestaurant")]
    public async Task<IActionResult> FindRestaurantAsync(int restaurantId)
    {
        var restaurant = await _restaurantService.FindRestaurantAsync(restaurantId);
        if (restaurant is null)
        {
            return NotFound();
        }
        return Ok(restaurant);
    }

    [HttpPost]
    public async Task<IActionResult> AddRestaurantAsync(RestaurantForCreationDto restaurantForCreationDto)
    {
        try
        {
            var addedRestaurant = await _restaurantService.AddRestaurantAsync(restaurantForCreationDto);
            return CreatedAtRoute(
                "FindRestaurant",
                new
                {
                    restaurantId = addedRestaurant.Id
                },
                addedRestaurant);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPut("{restaurantId:int}")]
    public async Task<IActionResult> UpdateRestaurantAsync(int restaurantId,RestaurantForUpdateDto restaurantForUpdateDto)
    {
        try
        {
            var restaurantDto = await _restaurantService.FindRestaurantAsync(restaurantId);
            if (restaurantDto is null)
            {
                return NotFound();
            }
            _mapper.Map(restaurantForUpdateDto, restaurantDto);
            await _restaurantService.UpdateRestaurantAsync(restaurantDto);
            return Ok($"The restaurant with ID {restaurantId} has been successfully Updated.");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    
    [HttpDelete("{restaurantId:int}")]
    public async Task<IActionResult> DeleteRestaurantAsync(int restaurantId)
    {
        try
        {
            if (await _restaurantService.FindRestaurantAsync(restaurantId) is null)
            {
                return BadRequest("No restaurant was found with the specified ID.");
            }
            await _restaurantService.DeleteRestaurantAsync(restaurantId);
            return Ok($"The restaurant with ID {restaurantId} has been successfully deleted.");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    
}
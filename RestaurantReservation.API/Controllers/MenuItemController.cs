using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Dtos.MenuItemDtos;
using RestaurantReservation.Services.MenuItemServices;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("api/menuItems")]
public class MenuItemController : Controller
{
    private readonly IMenuItemService _menuItemService;
    private readonly ILogger<EmployeeController> _logger;
    private readonly IMapper _mapper;

    public MenuItemController(ILogger<EmployeeController> logger, IMapper mapper, IMenuItemService menuItemService)
    {
        _logger = logger;
        _mapper = mapper;
        _menuItemService = menuItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMenuItemsAsync()
    {
        
        return Ok(await _menuItemService.GetMenuItemsAsync());
    }
    
    [HttpGet("{menuItemId:int}", Name = "FindMenuItem")]
    public async Task<IActionResult> FindMenuItemAsync(int menuItemId)
    {
        var menuItem = await _menuItemService.FindMenuItemAsync(menuItemId);
        if (menuItem is null)
        {
            return NotFound();
        }
        return Ok(menuItem);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddMenuItemAsync(MenuItemForCreationDto employeeForCreationDto)
    {
        try
        {
            var addedMenuItem = await _menuItemService.AddMenuItemAsync(employeeForCreationDto);
            
            if (addedMenuItem is null) 
                return BadRequest("Unable to process your request due to data constraints violation");
            
            return CreatedAtRoute(
                "FindMenuItem",
                new
                {
                    MenuItemId = addedMenuItem.Id
                },
                addedMenuItem);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    
    [HttpPut("{menuItemId:int}")]
    public async Task<IActionResult> UpdateMenuItemAsync(int menuItemId, MenuItemForUpdateDto menuItemForUpdateDto)
    {
        try
        {
            var menuItemDto = await _menuItemService.FindMenuItemAsync(menuItemId);
            if (menuItemDto is null)
            {
                return NotFound();
            }

            _mapper.Map(menuItemForUpdateDto, menuItemDto);
            await _menuItemService.UpdateMenuItemAsync(menuItemDto);
            return Ok($"The menuItem with ID {menuItemId} has been successfully Updated.");
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
    
    [HttpDelete("{menuItemId:int}")]
    public async Task<IActionResult> DeleteMenuItemAsync(int menuItemId)
    {
        try
        {
            if (await _menuItemService.FindMenuItemAsync(menuItemId) is null)
            {
                return BadRequest("No menuItem was found with the specified ID.");
            }
            await _menuItemService.DeleteMenuItemAsync(menuItemId);
            return Ok($"The menuItem with ID {menuItemId} has been successfully deleted.");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}
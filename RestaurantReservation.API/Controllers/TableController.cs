using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Dtos.TableDtos;
using RestaurantReservation.Services.TableServices;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("/api/tables")]
public class TableController : Controller
{
    private readonly ITableService _tableService;
    private readonly ILogger<EmployeeController> _logger;
    private readonly IMapper _mapper;


    public TableController(ITableService tableService, ILogger<EmployeeController> logger, IMapper mapper)
    {
        _tableService = tableService;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetTablesAsync()
    {
        return Ok(await _tableService.GetTablesAsync());
    }
    
    [HttpGet("{tableId:int}", Name = "FindTable")]
    public async Task<IActionResult> FindTableAsync(int tableId)
    {
        var table = await _tableService.FindTableAsync(tableId);
        if (table is null)
        {
            return NotFound();
        }
        return Ok(table);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddTableAsync(TableForCreationDto tableForCreationDto)
    {
        try
        {
            var addedTable = await _tableService.AddTableAsync(tableForCreationDto);
            
            if (addedTable is null) 
                return BadRequest("Unable to process your request due to data constraints violation");
            
            return CreatedAtRoute(
                "FindTable",
                new
                {
                    TableId = addedTable.Id
                },
                addedTable);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    
    [HttpPut("{tableId:int}")]
    public async Task<IActionResult> UpdateTableAsync(int tableId, TableForUpdateDto tableForUpdateDto)
    {
        try
        {
            var tableDto = await _tableService.FindTableAsync(tableId);
            if (tableDto is null)
            {
                return NotFound();
            }
            _mapper.Map(tableForUpdateDto, tableDto);
            await _tableService.UpdateTableAsync(tableDto);
            return Ok($"The table with ID {tableId} has been successfully Updated.");
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
    
    [HttpDelete("{tableId:int}")]
    public async Task<IActionResult> DeleteEmployeeAsync(int tableId)
    {
        try
        {
            if (await _tableService.FindTableAsync(tableId) is null)
            {
                return BadRequest("No table was found with the specified ID.");
            }
            await _tableService.DeleteTableAsync(tableId);
            return Ok($"The table with ID {tableId} has been successfully deleted.");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}
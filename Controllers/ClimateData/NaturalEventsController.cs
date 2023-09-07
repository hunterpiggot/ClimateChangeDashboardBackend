using ClimateChangeDashboardBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class NaturalEventsController : ControllerBase
{
    private readonly INaturalEventsService _naturalEventsService;

    public NaturalEventsController(INaturalEventsService naturalEventsService)
    {
        _naturalEventsService = naturalEventsService;
    }

    [HttpGet("natural-events")]
    public async Task<IActionResult> GetNaturalEventsData()
    {
        try
        {
            var naturalEventsData = await _naturalEventsService.GetNaturalEventsDataAsync();
            return Ok(naturalEventsData);
        }
        catch (Exception ex)
        {
            // Log the exception and return an appropriate error response
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching climate data." + ex);
        }
    }
}

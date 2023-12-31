using ClimateChangeDashboardBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class HistoricalDataController : ControllerBase
{
    private readonly IHistoricalDataService _historicalDataService;

    public HistoricalDataController(IHistoricalDataService historicalDataService)
    {
        _historicalDataService = historicalDataService;
    }

    [HttpGet("historical-data")]
    public async Task<IActionResult> GetHistoricalDataData([FromQuery] string startDateTime, [FromQuery] string endDateTime, string aggregation)
    {
        try
        {
            var historicalDataData = await _historicalDataService.GetHistoricalDataAsync(startDateTime, endDateTime, aggregation);
            return Ok(historicalDataData);
        }
        catch (Exception ex)
        {
            // Log the exception and return an appropriate error response
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching climate data." + ex);
        }
    }
}

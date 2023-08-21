using ClimateChangeDashboardBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class ClimateController : ControllerBase
{
    private readonly IClimateService _climateService;
    private readonly IUserRepository _userRepository;

    public ClimateController(IClimateService climateService, IUserRepository userRepository)
    {
        _climateService = climateService;
        _userRepository = userRepository;
    }

    [HttpGet("climate")]
    public async Task<IActionResult> GetClimateData([FromQuery] Guid userId)
    {
        try
        {
            // var climateData = await _climateService.FetchClimateDataAsync();
            var user = await _userRepository.GetUserByIdAsync(userId);
            Console.Write("------------" + user + "------------");
            if (user == null)
            {
                return NotFound("User not found");
            }
            var climateData = await _climateService.GetClimateDataAsync(user.State);
            return Ok(climateData);
        }
        catch (Exception ex)
        {
            // Log the exception and return an appropriate error response
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching climate data." + ex);
        }
    }
}

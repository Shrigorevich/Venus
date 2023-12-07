using Microsoft.AspNetCore.Mvc;
using Venus.Common;
using Venus.Domain;
using Venus.Dto;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Venus.Controllers;

[Route("api/challenges/days")]
[ApiController]
public class ChallengeDayController : ControllerBase
{
    private readonly IChallengeDayService _challengeDayService;
    private ILogger<ChallengeDayController> _logger;

    public ChallengeDayController(IChallengeDayService challengeDayService, ILogger<ChallengeDayController> logger)
    {
        _challengeDayService = challengeDayService;
        _logger = logger;
    }

    /// <summary>
    /// Creates challenge day
    /// </summary>
    /// <remarks></remarks>
    /// <returns>Created challenge day</returns>
    [HttpPost]
    public async Task<ActionResult> CreateChallengeDay([FromBody] CreateChallengeDayDto createChallengeDay)
    {
        try
        {
            var day = await _challengeDayService.CreateChallengeDay(createChallengeDay);
            return Ok(day);
        }
        catch (Exception e)
        {
            _logger.LogError("Something went wrong. Error: {0}", e);
            return StatusCode(500);
        }
    }
        
    /// <summary>
    /// Updates challenge day status
    /// </summary>
    /// <remarks></remarks>
    /// <returns></returns>
    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> UpdateChallengeDay(Guid id, [FromQuery] ChallengeDayStatus status)
    {
        try
        {
            await _challengeDayService.UpdateDayStatus(id, status);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError("Something went wrong. Error: {0}", e);
            return StatusCode(500);
        }
    }
}
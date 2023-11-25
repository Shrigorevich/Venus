using Microsoft.AspNetCore.Mvc;
using Venus.Common;
using Venus.Domain;
using Venus.Dto;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Venus.Controllers;

[Route("api/challenges/days")]
[ApiController]
public class ChallengeDayController(
    IChallengeDayService challengeDayService,
    ILogger logger) : ControllerBase
{
    /// <summary>
    /// Creates challenge day
    /// </summary>
    /// <remarks></remarks>
    /// <returns>Created challenge day</returns>
    [HttpPost]
    public async Task<ActionResult> CreateChallengeDay([FromBody] ChallengeDayDto challengeDay)
    {
        try
        {
            var day = await challengeDayService.CreateChallengeDay(challengeDay);
            return Ok(day);
        }
        catch (Exception e)
        {
            logger.LogError("Something went wrong. Error: {0}", e);
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
            await challengeDayService.UpdateDayStatus(id, status);
            return Ok();
        }
        catch (Exception e)
        {
            logger.LogError("Something went wrong. Error: {0}", e);
            return StatusCode(500);
        }
    }
}
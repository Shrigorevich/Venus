using Microsoft.AspNetCore.Mvc;
using Venus.Common;
using Venus.Domain;
using Venus.Domain.Contracts;
using Venus.Dto;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Venus.Controllers;

[Route("api/challenges/days")]
[ApiController]
public class ChallengeDayController(IChallengeDayService challengeDayService, ILogger<ChallengeDayController> logger)
    : ControllerBase
{
    /// <summary>
    /// Creates challenge day
    /// </summary>
    /// <remarks></remarks>
    /// <returns>Created challenge day</returns>
    [HttpPost]
    public async Task<ActionResult> CreateChallengeDay([FromBody] CreateChallengeDayDto challengeDay)
    {
        try
        {
            var isDateValid = DateTime.TryParse(challengeDay.Date, out var date);
            
            if (!isDateValid)
            {
                return BadRequest("Wrong date format. Please use ISO format (2023-10-05T14:48:00.000Z)");
            }
            
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
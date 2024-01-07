using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Venus.Common;
using Venus.Domain;
using Venus.Domain.Contracts;
using Venus.Dto;

namespace Venus.Controllers;

[Route("api/challenges")]
[ApiController]
public class ChallengeController(
    ILogger<ChallengeController> logger,
    IChallengeService challengeService)
    : ControllerBase
{
    /// <summary>
    /// Gets list of user`s challenges
    /// </summary>
    /// <remarks></remarks>
    /// <returns>List of challenges</returns>
    [HttpGet]
    public async Task<ActionResult> GetChallenges()
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            
            var challenges = await challengeService.GetChallenges(userId);
            return Ok(challenges);
        }
        catch (Exception e)
        {
            logger.LogError("Something went wrong. Error: {0}", e);
            return StatusCode(500);
        }
    }
        
    /// <summary>
    /// Creates new challenge
    /// </summary>
    /// <remarks></remarks>
    /// <returns>Created challenge</returns>
    [HttpPost]
    public async Task<ActionResult> CreateChallenge([FromBody]CreateChallengeDto challenge)
    {
        try
        {
            var isStartDateValid = DateTime.TryParse(challenge.StartDate, out var startDate);
            var isEndDateValid = DateTime.TryParse(challenge.EndDate, out var endDate) ||
                                 string.IsNullOrEmpty(challenge.EndDate);
                 

            if (!isStartDateValid || !isEndDateValid)
            {
                return BadRequest("Wrong date format. Please use ISO format (2023-10-05T14:48:00.000Z)");
            }

            if (isEndDateValid && startDate.ToShortDateString().Equals(endDate.ToShortDateString()))
            {
                return BadRequest("StartDate can`t be equal to EndDate");
            }
            
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            
            var createdChallenge = await challengeService.CreateChallenge(userId, challenge);
            return Ok(createdChallenge);
        }
        catch (Exception e)
        {
            logger.LogError("Something went wrong. Error: {0}", e);
            return StatusCode(500);
        }
    }
        
    /// <summary>
    /// Updates challenge status
    /// </summary>
    /// <remarks></remarks>
    /// <returns></returns>
    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> UpdateChallenge(Guid id, [FromQuery] ChallengeStatus status)
    {
        try
        {
            await challengeService.UpdateChallengeStatus(id, status);
            return Ok();
        }
        catch (Exception e)
        {
            logger.LogError("Something went wrong. Error: {0}", e);
            return StatusCode(500);
        }
    }
}
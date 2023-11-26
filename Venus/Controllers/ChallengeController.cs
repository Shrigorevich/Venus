using Microsoft.AspNetCore.Mvc;
using Venus.Common;
using Venus.Domain;
using Venus.Dto;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Venus.Controllers;

[Route("api/challenges")]
[ApiController]
public class ChallengeController(
    ILogger<ChallengeController> logger, 
    IChallengeService challengeService) : ControllerBase
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
            var userId = "test_user_1"; // temporary hardcoded
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
            var userId = "dfgadf"; //temp hardcoded
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
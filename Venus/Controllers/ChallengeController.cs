using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Venus.Common;
using Venus.Dto;

namespace Venus.Controllers
{
    [Route("api/challenges")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        public ChallengeController()
        {
            
        }

        /// <summary>
        /// Gets list of user`s challenges
        /// </summary>
        /// <returns>List of challenges</returns>
        [HttpGet]
        public async Task<ActionResult> GetChallenges()
        {
            return Ok();
        }
        
        /// <summary>
        /// Creates new challenge
        /// </summary>
        /// <returns>Created challenge</returns>
        [HttpPost]
        public async Task<ActionResult> CreateChallenge([FromBody]CreateChallengeDto challenge)
        {
            return Ok();
        }
        
        /// <summary>
        /// Updates challenge status
        /// </summary>
        /// <returns>List of challenges</returns>
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> CreateChallenge(Guid id, [FromQuery] ChallengeDayStatus status)
        {
            return Ok();
        }
    }
}

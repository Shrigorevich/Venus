using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Venus.Common;
using Venus.Domain.Contracts;
using Venus.Dto.Accounting;

namespace Venus.Controllers;

[Route("api/tags")]
[ApiController]
public class TagController(
    ITagService tagService,
    ILogger<TagController> logger) : ControllerBase
{
    /// <summary>
    /// Creates a new tag
    /// </summary>
    /// <returns>Created tag</returns>
    [HttpPost]
    public async Task<ActionResult> CreateTag([FromBody] DraftTagDto tag)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            
            var res = await tagService.CreateTag(userId, tag);
            return Ok(res);
        }
        catch (Exception e)
        {
            logger.LogError("Something went wrong. Error: {0}", e);
            return StatusCode(500, new ErrorObject
            {
                Message = e.Message
            });
        }
    }
    
    /// <summary>
    /// Updates the tag 
    /// </summary>
    /// <returns>Updated tag</returns>
    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateTag(int id, [FromBody] DraftTagDto tag)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            
            var res = await tagService.UpdateTag(id, tag);
            return Ok(res);
        }
        catch (Exception e)
        {
            logger.LogError("Something went wrong. Error: {0}", e);
            return StatusCode(500, new ErrorObject
            {
                Message = e.Message
            });
        }
    }
    
    /// <summary>
    /// Gets all user tags
    /// </summary>
    /// <returns>Tag list</returns>
    [HttpGet]
    public async Task<ActionResult> GetTags()
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            
            var res = await tagService.GetTags(userId);
            return Ok(res);
        }
        catch (Exception e)
        {
            logger.LogError("Something went wrong. Error: {0}", e);
            return StatusCode(500, new ErrorObject
            {
                Message = e.Message
            });
        }
    }
    
    /// <summary>
    /// Deletes the tag 
    /// </summary>
    /// <returns>Tag list</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteTag(int id)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            
            await tagService.DeleteTag(id);
            return Ok();
        }
        catch (Exception e)
        {
            logger.LogError("Something went wrong. Error: {0}", e);
            return StatusCode(500, new ErrorObject
            {
                Message = e.Message
            });
        }
    }
}
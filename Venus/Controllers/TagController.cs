using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Venus.Common;
using Venus.Domain;
using Venus.Dto.Accounting;

namespace Venus.Controllers;

[Route("api/tags")]
[ApiController]
public class TagController : ControllerBase
{
    private readonly ITagService _tagService;
    private readonly ILogger<TagController> _logger;

    public TagController(
        ITagService tagService, 
        ILogger<TagController> logger)
    {
        _tagService = tagService;
        _logger = logger;
    }
    
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
            
            var res = await _tagService.CreateTag(userId, tag);
            return Ok(res);
        }
        catch (Exception e)
        {
            _logger.LogError("Something went wrong. Error: {0}", e);
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
    public async Task<ActionResult> UpdateTag(int tagId, [FromBody] DraftTagDto tag)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            
            var res = await _tagService.UpdateTag(tagId, tag);
            return Ok(res);
        }
        catch (Exception e)
        {
            _logger.LogError("Something went wrong. Error: {0}", e);
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
            
            var res = await _tagService.GetTags(userId);
            return Ok(res);
        }
        catch (Exception e)
        {
            _logger.LogError("Something went wrong. Error: {0}", e);
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
            
            await _tagService.DeleteTag(id);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError("Something went wrong. Error: {0}", e);
            return StatusCode(500, new ErrorObject
            {
                Message = e.Message
            });
        }
    }
}
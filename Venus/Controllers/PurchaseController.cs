using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Venus.Common;
using Venus.Domain;
using Venus.Dto.Accounting;

namespace Venus.Controllers;

[Route("api/purchases")]
[ApiController]
public class PurchaseController : ControllerBase
{
    private readonly IPurchaseService _purchaseService;
    private ILogger<PurchaseController> _logger;

    public PurchaseController(IPurchaseService purchaseService, ILogger<PurchaseController> logger)
    {
        _purchaseService = purchaseService;
        _logger = logger;
    }
    
    /// <summary>
    /// Creates new purchase 
    /// </summary>
    /// <remarks></remarks>
    /// <returns>Created purchase</returns>
    [HttpPost]
    public async Task<ActionResult> CreatePurchase([FromBody]CreatePurchaseDto purchase)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            
            var createdPurchase = await _purchaseService.CreatePurchase(userId, purchase);
            return Ok(createdPurchase);
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
    /// Gets list of user`s purchases
    /// </summary>
    /// <remarks></remarks>
    /// <returns>List of purchases</returns>
    [HttpGet]
    public async Task<ActionResult> GetPurchases()
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            
            var purchases = await _purchaseService.GetPurchases(userId);
            return Ok(purchases);
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
    /// Creates new purchase 
    /// </summary>
    /// <remarks></remarks>
    /// <returns>Add</returns>
    [HttpPut("{id:Guid}/tags")]
    public async Task<ActionResult> AddPurchaseTag([FromQuery] int tagId, Guid id)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            
            await _purchaseService.AddPurchaseTag(id, tagId);
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
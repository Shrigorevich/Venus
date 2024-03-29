using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Venus.Common;
using Venus.Domain;
using Venus.Domain.Contracts;
using Venus.Dto.Accounting;

namespace Venus.Controllers;

[Route("api/purchases")]
[ApiController]
public class PurchaseController(
    IPurchaseService purchaseService,
    ILogger<PurchaseController> logger)
    : ControllerBase
{
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
            var isDateValid = DateOnly.TryParse(purchase.Date, out var date);
            if (!isDateValid)
                return BadRequest("Wrong date format. Please use ISO format (2023-10-05T14:48:00.000Z)");
            
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            // if (string.IsNullOrEmpty(userId)) return Unauthorized();

            userId = "test_user";
            var createdPurchase = await purchaseService.CreatePurchase(userId, purchase);
            return Ok(createdPurchase);
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
    /// Updates purchase 
    /// </summary>
    /// <remarks></remarks>
    /// <returns>Updated purchase</returns>
    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> UpdatePurchase(Guid id, [FromBody]UpdatePurchaseDto purchase)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            // if (string.IsNullOrEmpty(userId)) return Unauthorized();
            userId = "test_user";
            var createdPurchase = await purchaseService.UpdatePurchase(userId, id, purchase);
            return Ok(createdPurchase);
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
            // if (string.IsNullOrEmpty(userId)) return Unauthorized();
            userId = "test_user";
            var purchases = await purchaseService.GetPurchases(userId);
            return Ok(purchases);
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
    /// Delete purchase
    /// </summary>
    /// <remarks></remarks>
    /// <returns></returns>
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeletePurchase(Guid id)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            await purchaseService.DeletePurchase(userId, id);
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
    
    /// <summary>
    /// Delete purchase
    /// </summary>
    /// <remarks></remarks>
    /// <returns>Add</returns>
    [HttpPut("{id:Guid}/tags")]
    public async Task<ActionResult> UpdatePurchaseTags(Guid id, [FromBody] int[] tagIds)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            await purchaseService.UpdatePurchaseTags(id, tagIds);
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
    
    /// <summary>
    /// Dummy API
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPut("dummy")]
    public async Task<ActionResult> Dummy([FromQuery] string userId)
    {
        try
        {
            var res = await purchaseService.GetPurchases(userId);
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
}
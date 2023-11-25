using Microsoft.AspNetCore.Mvc;
using Venus.Domain;
using Venus.Dto.Accounting;

namespace Venus.Controllers;

[Route("api/purchases")]
[ApiController]
public class PurchaseController(
    ILogger logger, 
    IPurchaseService purchaseService) : ControllerBase
{
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
            var userId = "test_user"; // temporary hardcoded
            var purchases = await purchaseService.GetPurchases(userId);
            return Ok(purchases);
        }
        catch (Exception e)
        {
            logger.LogError("Something went wrong. Error: {0}", e);
            return StatusCode(500);
        }
    }
        
    /// <summary>
    /// Creates new purchase 
    /// </summary>
    /// <remarks></remarks>
    /// <returns>Created purchase</returns>
    [HttpPost]
    public async Task<ActionResult> CreateChallenge([FromBody]CreatePurchaseDto purchase)
    {
        try
        {
            var userId = "dfgadf"; //temp hardcoded
            var createdPurchase = await purchaseService.CreatePurchase(userId, purchase);
            return Ok(createdPurchase);
        }
        catch (Exception e)
        {
            logger.LogError("Something went wrong. Error: {0}", e);
            return StatusCode(500);
        }
    }
}
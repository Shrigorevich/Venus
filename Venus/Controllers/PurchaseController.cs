using Microsoft.AspNetCore.Mvc;
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
            var purchases = await _purchaseService.GetPurchases(userId);
            return Ok(purchases);
        }
        catch (Exception e)
        {
            _logger.LogError("Something went wrong. Error: {0}", e);
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
            var userId = "test_user"; //temp hardcoded
            var createdPurchase = await _purchaseService.CreatePurchase(userId, purchase);
            return Ok(createdPurchase);
        }
        catch (Exception e)
        {
            _logger.LogError("Something went wrong. Error: {0}", e);
            return StatusCode(500);
        }
    }
}
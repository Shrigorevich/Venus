using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Venus.Common;
using Venus.Domain;
using Venus.Dto.Accounting;

namespace Venus.Controllers;

[Route("api/budgets")]
[ApiController]
public class BudgetController : ControllerBase
{
    private readonly IBudgetService _budgetService;
    private readonly ILogger<BudgetController> _logger;

    public BudgetController(
        IBudgetService budgetService, 
        ILogger<BudgetController> logger)
    {
        _budgetService = budgetService;
        _logger = logger;
    }
    
    /// <summary>
    /// Creates a new Budget
    /// </summary>
    /// <returns>Created budget</returns>
    [HttpPost]
    public async Task<ActionResult> CreateBudget([FromBody] CreateBudgetDto budget)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            
            var res = await _budgetService.CreateBudget(userId, budget);
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
    /// Updates the Budget 
    /// </summary>
    /// <returns>Updated Budget</returns>
    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateBudget(int id, [FromBody] CreateBudgetDto budget)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            
            var res = await _budgetService.UpdateBudget(id, budget);
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
    /// Gets all user Budgets
    /// </summary>
    /// <returns>Budget list</returns>
    [HttpGet]
    public async Task<ActionResult> GetBudgets()
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            
            var res = await _budgetService.GetBudgets(userId);
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
    /// Deletes the Budget 
    /// </summary>
    /// <returns>Budget list</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteBudget(int id)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            
            await _budgetService.DeleteBudget(id);
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
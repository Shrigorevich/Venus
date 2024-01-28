using Microsoft.AspNetCore.Mvc;
using Venus.Common;
using Venus.Domain.Contracts;

namespace Venus.Controllers;

[Route("api/configuration")]
[ApiController]
public class ConfigurationController(
    IConfigurationService configurationService,
    ILogger<ConfigurationController> logger) : ControllerBase
{
    /// <summary>
    /// Gets configuration ( currencies, ... )
    /// </summary>
    /// <returns>Configuration</returns>
    [HttpGet]
    public async Task<ActionResult> GetConfiguration()
    {
        try
        {
            var res = await configurationService.GetConfiguration();
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
using Microsoft.AspNetCore.Mvc;

namespace SWD.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SWDController : ControllerBase
{

    private readonly ILogger<SWDController> _logger;

    public SWDController(ILogger<SWDController> logger)
    {
        _logger = logger;
    }

    [HttpGet("[action]")]
    public ActionResult<bool> GetResult()
    {
        return true;
    }
}
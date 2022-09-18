using Microsoft.AspNetCore.Mvc;

namespace Tickets.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProcessController : Controller
{
    private readonly ILogger<ProcessController> _logger;
    
    public ProcessController(ILogger<ProcessController> logger)
    {
        _logger = logger;
    }
    
    
    
}
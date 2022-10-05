using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;

using Tickets.Model;
using Tickets.Model.DTO;
using Tickets.Services;
using Tickets.Services.JSONValidation;

namespace Tickets.Controllers.V1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class ProcessController : Controller
{
    private readonly ILogger<ProcessController> _logger;
    private readonly IConfiguration _configuration;

    public ProcessController(ILogger<ProcessController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    
    [HttpPost]
    [Route("sale")]
    public async Task<ActionResult> PostSale([FromBody]JsonNode body)
    {
        JSONValidationService validationService = new JSONValidationService(_configuration);
        if (validationService.IsValidSell(body))
            return Ok();
        else return Conflict();

    }
    
    [HttpPost]
    [Route("refund")]
    public async Task<ActionResult> PostRefund([FromBody]JsonNode body)
    {
        SoldTicketDto soldTicket = JsonSerializer.Deserialize<SoldTicketDto>(body);
        Console.Out.WriteLine(soldTicket);
        return Ok(soldTicket);
    }
    
    
}
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;

using Tickets.Model;
using Tickets.Model.DTO;
using Tickets.Services;
using Tickets.Validation.JsonValidation;

namespace Tickets.Controllers.V1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class ProcessController : ControllerBase
{
    private readonly ITicketService _ticketService;


    public ProcessController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    
    [HttpPost]
    [Route("sale")]
    public async Task<ActionResult> PostSale([FromBody]JsonNode? body)
    {
        
        return await _ticketService.ProcessTicketSell(body.Deserialize<SoldTicketDto>());
    }
    
    [HttpPost]
    [Route("refund")]
    public async Task<ActionResult> PostRefund([FromBody]JsonNode? body)
    {
       return await _ticketService.ProcessTicketRefund(body.Deserialize<RefundedTicketDto>());
       
    }
    
    
}
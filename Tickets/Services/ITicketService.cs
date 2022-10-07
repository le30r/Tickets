using Microsoft.AspNetCore.Mvc;
using Tickets.Model.DTO;

namespace Tickets.Services;

public interface ITicketService
{
    public Task<ActionResult> ProcessTicketSell(SoldTicketDto? ticketDto);
    public Task<ActionResult> ProcessTicketRefund(RefundedTicketDto? ticketDto);
}
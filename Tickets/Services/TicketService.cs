
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tickets.Data;
using Tickets.Model;
using Tickets.Model.DTO;
using Tickets.Validation;

namespace Tickets.Services;

public class TicketService : ITicketService
{
    private readonly SegmentRepository _repository;
    private readonly EntityValidator _validator;

    public TicketService(SegmentRepository repository, EntityValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<ActionResult> ProcessTicketSell(SoldTicketDto? ticketDto)
    {
        if (_validator.IsSellEntityValid(ticketDto.Passenger))
        {
            var segments = SegmentMapper.Map(ticketDto: ticketDto);
            await _repository.SaleTicketAsync(segments);
        }
        else
        {
            throw new ValidationException();
        }

        return new OkResult();
    }

    public async Task<ActionResult> ProcessTicketRefund(RefundedTicketDto? ticketDto)
    {
        if (_validator.IsRefundEntityValid(ticketDto))
        {
            await _repository.RefundTicketAsync(ticketDto);
        }
        else
        {
            throw new ValidationException();
        }

        return new OkResult();
    }
}
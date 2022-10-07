using System.Data.Entity.Core;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tickets.Model;
using Tickets.Model.DTO;


namespace Tickets.Data;

public class SegmentRepository
{
    private readonly TicketsContext _context;
    private const string SqlSetTimeout = "SET LOCAL lock_timeout = \'120s\';";

    private const string SqlUpdateTickets 
        = "UPDATE segments SET state = 'refunded' WHERE ticket_number = {0} AND state <> 'refunded'";

    public SegmentRepository(TicketsContext context)
    {
        _context = context;
    }

    public async Task SaleTicketAsync(IEnumerable<Segment> segments)
    {
        await using var transaction = 
            await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);
        await _context.Database.ExecuteSqlRawAsync(SqlSetTimeout);
        await _context.Segments.AddRangeAsync(segments);
        await _context.SaveChangesAsync();
        await transaction.CommitAsync();
    }

    public async Task RefundTicketAsync(RefundedTicketDto? ticketDto)
    {
        var number = ticketDto.TicketNumber;
        await using var transaction = 
            await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);
        await _context.Database.ExecuteSqlRawAsync(SqlSetTimeout);
        
        int result = await _context.Database.ExecuteSqlRawAsync(SqlUpdateTickets, number);
        if (result == 0)
        {
            await transaction.RollbackAsync();
            throw new DbUpdateException();
        }
        else
        {
            await transaction.CommitAsync();
        }
    }
}
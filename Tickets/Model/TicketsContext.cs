using Microsoft.EntityFrameworkCore;

namespace Tickets.Model;

public class TicketsContext : DbContext
{

    public TicketsContext(DbContextOptions<TicketsContext> options)
        : base(options)
    {
        
    }
}
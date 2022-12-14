using Microsoft.EntityFrameworkCore;
using Tickets.Model;

namespace Tickets.Data;

public class TicketsContext : DbContext
{

    public TicketsContext(DbContextOptions<TicketsContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Segment>()
            .HasKey(s => new { s.TicketNumber, s.SerialNumber }).HasName("PK_TicketSerial");
    }
    
    public DbSet<Segment>? Segments { get; set; }
}
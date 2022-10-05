using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Tickets.Model;

[Table("segments")]
public class Segment
{
    [Column("ticket_number")]
    public string TicketNumber { get; set; }
    
    [Column("serial_number")]
    public string SerialNumber { get; set; }
    
    public string AirlineCode { get; set; }

    [Column("flight_num")] 
    public long FlightNum { get; set; }
    
    [Column("depart_place")]
    public string DepartPlace { get; set; }
    
    [Column("depart_datetime")]
    public DateTime DepartDateTime { get; set; }
    
    [Column("arrive_place")]
    public string ArrivePlace { get; set; }

    [Column("arrive_datetime")]
    public string ArriveDateTime { get; set; }
    
    [Column("pnr_id")]
    public string PnrId { get; set; }
    
    [Column("state")]
    public string State { get; set; }
}
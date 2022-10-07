using System.ComponentModel.DataAnnotations.Schema;


namespace Tickets.Model;

[Table("segments")]
public class Segment
{
    [Column("operation_time")]
    public DateTime OperationTime { get; set; }
    
    [Column("operation_time_timezone")]
    public short OperationTimeTimezone { get; set; }
    
    [Column("ticket_number")]
    public string TicketNumber { get; set; }
    
    [Column("serial_number")]
    public int SerialNumber { get; set; }
    
    [Column("airline_code")]
    public string AirlineCode { get; set; }

    [Column("flight_num")] 
    public long FlightNum { get; set; }
    
    [Column("depart_place")]
    public string DepartPlace { get; set; }
    
    [Column("depart_datetime")]
    public DateTime DepartDateTime { get; set; }
    
    [Column("depart_datetime_timezone")]
    public short DepartDateTimeTimezone { get; set; }
    
    [Column("arrive_place")]
    public string ArrivePlace { get; set; }

    [Column("arrive_datetime")]
    public DateTime ArriveDateTime { get; set; }
    
    [Column("arrive_datetime_timezone")]
    public short ArriveDateTimeTimezone { get; set; }
    
    [Column("pnr_id")]
    public string PnrId { get; set; }
    
    [Column("state")]
    public string State { get; set; }
    
}

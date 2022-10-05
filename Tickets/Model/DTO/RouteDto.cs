using System.Text.Json.Serialization;

namespace Tickets.Model.DTO;

public class RouteDto
{
    [JsonPropertyName("airline_code")]
    public string AirlineCode { get; set; }

    [JsonPropertyName("flight_num")] 
    public long FlightNum { get; set; }
    
    [JsonPropertyName("depart_place")]
    public string DepartPlace { get; set; }
    
    [JsonPropertyName("depart_datetime")]
    public DateTime DepartDateTime { get; set; }
    
    [JsonPropertyName("arrive_place")]
    public string ArrivePlace { get; set; }

    [JsonPropertyName("arrive_datetime")]
    public string ArriveDateTime { get; set; }
    
    [JsonPropertyName("pnr_id")]
    public string PnrId { get; set; }

    public RouteDto(long flightNum, string airlineCode, string departPlace, DateTime departDateTime, string arrivePlace, string arriveDateTime, string pnrId)
    {
        FlightNum = flightNum;
        AirlineCode = airlineCode;
        DepartPlace = departPlace;
        DepartDateTime = departDateTime;
        ArrivePlace = arrivePlace;
        ArriveDateTime = arriveDateTime;
        PnrId = pnrId;
    }
}
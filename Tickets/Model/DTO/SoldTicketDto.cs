using System.Text.Json.Serialization;

namespace Tickets.Model.DTO;

public class SoldTicketDto
{
   
    [JsonPropertyName("operation_type")]
    public string OperationType { get; set; }
    
    
    [JsonPropertyName("operation_time")]
    public DateTime OperationTime { get; set; }
    
    [JsonPropertyName("operation_place")]
    public string OperationPlace { get; set; }
    
    [JsonPropertyName("passenger")]
    public PassengerDto Passenger { get; set; }
    
    [JsonPropertyName("routes")]
    public List<RouteDto> Routes { get; set; }
}
using System.Text.Json.Serialization;

namespace Tickets.Model.DTO;

public class SoldTicketDto
{
   
    [JsonPropertyName("operation_type")]
    public string OperationType { get; set; }
    
    
    [JsonPropertyName("operation_time")]
    public DateTimeOffset OperationTime { get; set; }
    
    [JsonPropertyName("operation_place")]
    public string OperationPlace { get; set; }
    
    [JsonPropertyName("passenger")]
    public PassengerDto Passenger { get; set; }
    
    [JsonPropertyName("routes")]
    public List<RouteDto> Routes { get; set; }

    public SoldTicketDto(string operationType, DateTimeOffset operationTime, string operationPlace, PassengerDto passenger, List<RouteDto> routes)
    {
        OperationType = operationType;
        OperationTime = operationTime;
        OperationPlace = operationPlace;
        Passenger = passenger;
        Routes = routes;
    }
}
using System.Text.Json.Serialization;

namespace Tickets.Model.DTO;

public class RefundedTicketDto
{

    [JsonPropertyName("operation_type")]
    public string OperationType { get; set; }
    
    
    [JsonPropertyName("operation_time")]
    public DateTime OperationTime { get; set; }
    
    [JsonPropertyName("operation_place")]
    public string OperationPlace { get; set; }

    [JsonPropertyName("ticket_number")] 
    public string TicketNumber { get; set; }

    public RefundedTicketDto(string operationType, DateTime operationTime, string operationPlace, string ticketNumber)
    {
        OperationType = operationType;
        OperationTime = operationTime;
        OperationPlace = operationPlace;
        TicketNumber = ticketNumber;
    }
}
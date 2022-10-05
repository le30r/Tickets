using System.Text.Json.Serialization;

namespace Tickets.Model.DTO;

public class PassengerDto
{

    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("surname")]
    public string Surname { get; set; }
    
    [JsonPropertyName("patronymic")]
    public string Patronymic { get; set; }
    

    [JsonPropertyName("doc_type")]
    public string DocType { get; set; }
    
    [JsonPropertyName("doc_number")]
    public string DocNumber { get; set; }
    
    [JsonPropertyName("birthdate")]
    public DateTime Birthdate { get; set; }
    
    [JsonPropertyName("gender")]
    public char Gender { get; }
    
    [JsonPropertyName("passenger_type")]
    public string PassengerType { get; set; }
    
    [JsonPropertyName("ticket_number")]
    public string TicketNumber { get; set; }

    public PassengerDto(string name, string surname, string patronymic, string docType, string docNumber, 
                            DateTime birthdate, char gender, string passengerType, string ticketNumber)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        DocType = docType;
        DocNumber = docNumber;
        Birthdate = birthdate;
        Gender = gender;
        PassengerType = passengerType;
        TicketNumber = ticketNumber;
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, " +
               $"{nameof(Surname)}: {Surname}, " +
               $"{nameof(Patronymic)}: {Patronymic}, " +
               $"{nameof(DocType)}: {DocType}, " +
               $"{nameof(DocNumber)}: {DocNumber}, " +
               $"{nameof(Birthdate)}: {Birthdate}, " +
               $"{nameof(Gender)}: {Gender}, " +
               $"{nameof(PassengerType)}: {PassengerType}, " +
               $"{nameof(TicketNumber)}: {TicketNumber}";
    }
}
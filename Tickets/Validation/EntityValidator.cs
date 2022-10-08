using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Tickets.Model.DTO;

namespace Tickets.Validation;

public class EntityValidator
{
    private const int TicketNumberLength = 13;
    private const int DocnumLength = 10;

    public bool IsSellEntityValid(PassengerDto passengerDto)
    {
        var isValid = (IsGenderValid(passengerDto.Gender)
                       && IsTicketNumberValid(passengerDto.TicketNumber)
                       && IsDocTypeAndNumberValid(passengerDto.DocType, passengerDto.DocNumber))
                      && IsBirthdateValid(passengerDto.Birthdate);
        
        return isValid;
    }

    public bool IsRefundEntityValid(RefundedTicketDto refundedTicketDto)
    {
        return IsTicketNumberValid(refundedTicketDto.TicketNumber);
    }

    private bool IsTicketNumberValid(string ticketNumber)
    {
        return Regex.IsMatch(ticketNumber, "^[0-9]+$") 
               && ticketNumber.Length == TicketNumberLength;
    }

    private bool IsGenderValid(char gender)
    {
        return gender is 'M' or 'F';
    }

    private bool IsDocTypeAndNumberValid(string docType, string docNumber)
    {
        return docType != "00" || (docNumber.Length == DocnumLength);
    }

    private bool IsBirthdateValid(DateTime birthDate)
    {
        return birthDate.AddYears(18) < DateTime.UtcNow.Date;
    }
}
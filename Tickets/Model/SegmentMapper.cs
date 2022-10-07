using Tickets.Model.DTO;

namespace Tickets.Model;

public class SegmentMapper
{
    protected SegmentMapper()
    { }
    public static IEnumerable<Segment> Map(SoldTicketDto? ticketDto)
    {
        ICollection<Segment> result = new List<Segment>();
        int i = 1;
        foreach (var route in ticketDto.Routes)
        {
            result.Add(new Segment()
            {
                OperationTime = ticketDto.OperationTime.UtcDateTime,
                OperationTimeTimezone = GetTimeZone(dateTime: ticketDto.OperationTime),
                TicketNumber = ticketDto.Passenger.TicketNumber,
                SerialNumber = i++,
                AirlineCode = route.AirlineCode,
                FlightNum = route.FlightNum,
                DepartPlace = route.DepartPlace,
                DepartDateTime = route.DepartDateTime.UtcDateTime,
                DepartDateTimeTimezone = GetTimeZone(dateTime: route.DepartDateTime),
                ArrivePlace = route.ArrivePlace,
                ArriveDateTime = route.ArriveDateTime.UtcDateTime,
                ArriveDateTimeTimezone = GetTimeZone(route.ArriveDateTime),
                PnrId = route.PnrId,
                State = "sold"
            });
        }
        return result;
    }

    private static short GetTimeZone(DateTimeOffset dateTime)
    {
        return (short)dateTime.Offset.Hours;
    }
}
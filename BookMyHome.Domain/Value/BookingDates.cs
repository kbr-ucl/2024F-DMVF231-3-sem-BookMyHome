namespace BookMyHome.Domain.Value;

public record BookingDates
{

    public DateOnly Arrival { get; }
    public DateOnly Departure { get; }

    public BookingDates(DateOnly Arrival, DateOnly Departure)
    {
        if (Arrival > Departure)
        {
            throw new ArgumentException("Arrival date must be before departure date");
        }

        this.Arrival = Arrival;
        this.Departure = Departure;
    }
    public int DurationInDays => Departure.DayNumber - Arrival.DayNumber;

    public bool IsOverlap(BookingDates exsistingBookingDates)
    {
        throw new NotImplementedException();
    }
}
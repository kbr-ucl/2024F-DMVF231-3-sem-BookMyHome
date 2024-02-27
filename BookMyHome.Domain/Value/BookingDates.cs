using BookMyHome.Domain.Shared;

namespace BookMyHome.Domain.Value;

// https://stackoverflow.com/questions/64784374/c-sharp-9-records-validation
public record BookingDates(DateOnly Arrival, DateOnly Departure) : RecordWithValidation
{
    public int DurationInDays => Departure.DayNumber - Arrival.DayNumber;

    protected override void Validate()
    {
        if (Arrival > Departure) throw new ArgumentException("Arrival date must be before departure date");
    }
}
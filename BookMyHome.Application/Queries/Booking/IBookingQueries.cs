namespace BookMyHome.Application.Queries.Booking;

public interface IBookingQueries
{
    BookingQueryDto GetBooking(Guid id);
    IEnumerable<BookingQueryDto> GetBookingsByAccommodation(Guid accommodationId);
    IEnumerable<BookingQueryDto> GetBookingsByUser(Guid userId);
}